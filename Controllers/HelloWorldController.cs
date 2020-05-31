using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace Cwieczenie_12.Controllers
{
    public class HelloWorldController : Controller
    {

        public IActionResult Index() {
            return View();        
        }

        /*
        public string Index()
        {
            return "This is my default action...";
            // return View();
        }
        */

        // GET: /HelloWorld/Welcome/ 
        // Requires using System.Text.Encodings.Web;
        /*
        public string Welcome(string name, int ID = 1) 
        {
            
            return HtmlEncoder.Default.Encode($"Hello {name}, NumerTimes is: {ID}");
            // return "This is the Welcome action method...";
        }
        */
        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;
            
            return View();
        }

    }
}