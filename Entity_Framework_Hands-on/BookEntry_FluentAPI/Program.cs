using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise1   //DO NOT change the namespace name
{
    public class Program   //DO NOT change the class name
    {
        static void Main(string[] args)      //DO NOT change the 'Main' method signature
        {
            //Implement code here
             BookUtil bookUtil = new BookUtil();

            // Add a book
            Book book1 = new Book { BookName = "HarryPotter", BookAuthor = "JK Rowling", BookGenre = "Fantasy", BookPrice = 1000 };
            bookUtil.AddBook(book1);
            Console.WriteLine("Details Added Successfully.");

            // Add another book
            Book book2 = new Book { BookName = "The Hobbit", BookAuthor = "JRR", BookGenre = "Adventure", BookPrice = 1200 };
            bookUtil.AddBook(book2);
            Console.WriteLine("Details Added Successfully.");

            // Get books by genre
            List<Book> adventureBooks = bookUtil.GetBookByGenre("Adventure");
            foreach (var book in adventureBooks)
            {
                Console.WriteLine($"{book.BookName}—{book.BookAuthor}");
            }

            // Get all books
            List<Book> allBooks = bookUtil.GetBooksList();
            foreach (var book in allBooks)
            {
                Console.WriteLine($"{book.BookAuthor}--{book.BookId}");
            }

            // Update book price
            bookUtil.UpdateBookPrice(1500, book1.BookId);

            // Delete a book
            bookUtil.DeleteBook(book2.BookId);
        }
    }
}