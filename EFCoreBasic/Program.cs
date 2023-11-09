using EFCoreBasic.Database;
using Microsoft.EntityFrameworkCore;
using System;

namespace EFCoreBasic;

public class Program
{
    public static void ListAll()
    {
        using (var context = new Context())
        {
            foreach (Book book in
                context.Books
                // AsNoTracking indicates that this access is read-only
                .AsNoTracking()
                // Causes the author information to be loaded with each book 
                .Include(book => book.Author))
            {
                string webUrl = book.Author.WebUrl ?? "Error: WebUrl = NULL";

                Console.WriteLine($"{book.Title} by {book.Author.Name}");
                Console.WriteLine("     " 
                    + "Published on " 
                    + $"{book.PublishedOn:dd-MMM-yyyy}" 
                    + $". {webUrl}");
            }
        }
    }

    public static void ChangeWebUrl()
    {
        Console.WriteLine("New Quantum Networking WebUrl > ");
        var inputWebUrl = Console.ReadLine();

        using(var context = new Context())
        {
            Book singleBook = context.Books
                .Include(book => book.Author)
                .Single(book => book.Title == "Quantum Networking");

            singleBook.Author.WebUrl = inputWebUrl;
            context.SaveChanges();
            Console.WriteLine("... SaveChanges called.");
        }

        ListAll();
    }

    public static void Main()
    {
        Console.WriteLine("Hello, world!");
    }
}