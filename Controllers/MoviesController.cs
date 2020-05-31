using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Cwieczenie_12.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace Cwieczenie_12.Controllers
{
    public class MoviesController : Controller
    {
        private readonly s19314Context _context ;
        public MoviesController(s19314Context dbContext) 
        {
            _context = dbContext;
        }
        public async Task<IActionResult> Index(string moviesGenre, string searchString)
        {
            IQueryable<string> genreQuery = from m in _context.Movie
                                            orderby m.Genre
                                            select m.Genre;
            
            var movies = from m in _context.Movie
                         select m;
            if (!String.IsNullOrEmpty(searchString)) 
            {
                movies = movies.Where(s => s.Title.Contains(searchString));
            }

            if (!String.IsNullOrEmpty(moviesGenre))
            {
                movies = movies.Where(s => s.Title.Contains(moviesGenre));
            }

            var movieGenreVM = new MovieGenreViewModel
            {
                Genres = new SelectList(await genreQuery.Distinct().ToListAsync()),
                Movies =  await movies.ToListAsync()
            };
  

                return View(movieGenreVM);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed) 
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }


        // GET: Movies/Details/1
        public async Task<IActionResult> Details(int? id) 
        {
            if (id == null) return NotFound();
            var movie =  _context.Movie
                .FirstOrDefault(m => m.Id == id);
            if (movie == null) return NotFound();

            return View(movie);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var movie = await _context.Movie.FindAsync(id);
            if (movie == null) return NotFound();
            return View(movie);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,RealeaseDate,Genre,Price,Rating")] Movie movie) 
        {
            if (id != movie.Id) return NotFound();
            if (ModelState.IsValid) 
            {
                try
                {
                    _context.Update(movie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) {
                    if (!MovieExists(movie.Id)) return NotFound();
                    else throw;
                
                }
                return RedirectToAction(nameof(Index));
            }
            return View(movie);
        }


        private bool MovieExists(int id) {
            var movie = _context.Movie.Select(e => e.Id).Where(e => (e == id));
            if (movie.Count() == 0) return false;
            return true;
        }

        // GET: Movies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Movies/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("ID,Title,ReleaseDate,Genre,Price, Rating")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(movie);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        public async Task<IActionResult> Delete(int? id) {
            if (id == null) 
            {
                return NotFound();    
            }

            var movie = await _context.Movie
                              .FirstOrDefaultAsync(m => m.Id == id);
            if (movie == null) 
            {
                return NotFound();
            }

            return View(movie);
        }   


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id, bool notused)
        {
            var movie = await _context.Movie.FindAsync(id);
            _context.Movie.Remove(movie);
            await _context.SaveChangesAsync();
            
            return RedirectToAction(nameof(Index));
        }

    }
}