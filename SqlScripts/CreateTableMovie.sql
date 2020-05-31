BEGIN TRANSACTION;
CREATE TABLE Movie(
	Id Integer Primary Key,
	Title Varchar(100),
	RealeaseDate Date,
	Price Decimal(4, 2) 
);

SELECT * FROM Movie;
INSERT INTO Movie(Id, Title, RealeaseDate, Price)
VALUES(1, 'Ja - Robot', GETDATE(), 10.2);	
COMMIT;