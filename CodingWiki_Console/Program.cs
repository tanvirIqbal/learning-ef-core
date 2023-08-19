// See https://aka.ms/new-console-template for more information
using CodingWiki_DataAccess.Data;
using CodingWiki_DataAccess.Migrations;
using CodingWiki_Models.Models;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");


//using(ApplicationDBContext context = new())
//{
//    context.Database.EnsureCreated();
//	if (context.Database.GetPendingMigrations().Count() > 0)
//	{
//		context.Database.Migrate();
//	}
//}

//AddBook();
//GetBooks();
//GetBook();
//UpdateBook();
DeleteBook();

void DeleteBook()
{
    using var context = new ApplicationDBContext();
    Book book = context.Books.First();
    context.Books.Remove(book);
    context.SaveChanges();
}

void UpdateBook()
{
    using var context = new ApplicationDBContext();
    Book book = context.Books.First();
    book.Price = 10.50m;
    context.SaveChanges();
}

void GetBook()
{
    using var context = new ApplicationDBContext();
    //Book book = context.Books.First();
    //Book book = context.Books.FirstOrDefault();
    //Book book = context.Books.Where(x => x.Publisher_Id == 3 && x.Price > 30).FirstOrDefault();
    //Book book = context.Books.Find(1);
    Book book = context.Books.Where(x => EF.Functions.Like(x.ISBN,"12")).FirstOrDefault();
    decimal maxPrice = context.Books.Max(x => x.Price);
    int bookCount = context.Books.Count();
    Console.WriteLine(book.Title + " - " + book.ISBN);
}

void GetBooks()
{
    using var context = new ApplicationDBContext();
    var books = context.Books.OrderBy(x => x.Title).ThenByDescending(x => x.Price).ToList();
    
    foreach (var book in books)
    {
        Console.WriteLine(book.Title + " - " + book.ISBN);
    }
}
void AddBook()
{
    Book book = new Book()
    {
        Title = "New EF Core Book",
        ISBN = "123456789",
        Price = 15.63m,
        Publisher_Id = 1
    };
    using var context = new ApplicationDBContext();
    var books = context.Books.Add(book);
    context.SaveChanges();
}