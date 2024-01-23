using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ArchiveManagement
{
    public class Program
    {
        public static SortedDictionary<int,Book> bookDetails= new SortedDictionary<int,Book>();
        public SortedDictionary<string,List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string,List<Book>> dict = new SortedDictionary<string,List<Book>>();
            foreach(Book b in bookDetails.Values)
            {
                if (dict.ContainsKey(b.Genre))
                {
                    List<Book> list = dict[b.Genre];
                    list.Add(b);
                    dict[b.Genre] = list;
                }
                else
                {
                    dict.Add(b.Genre, new List<Book>() {b});
                }
            }
            return dict;
        }
 
        public Dictionary<string, double> UpdatePenaltyAmount(double amount)
        {
            Dictionary<string,double> dict = new Dictionary<string,double>();
            foreach(Book b in bookDetails.Values)
            {
                string[] d1 = b.IssueDate.Split('/');
                string[] d2 = b.ReturnDate.Split('/');
                if (d1[2] == d2[2] && d1[0] == d2[0])
                {
                    int days = int.Parse(d2[1]) - int.Parse(d1[1]);
                    if (days >= 3)
                    {
                        b.Penalty = amount;
                        dict.Add(b.MemberID, b.Penalty);
                    }
                }
            }
            return dict;
        }
 
        public List<string> FindBooksNameWithSameDayReturn()
        {
            List<string> list = new List<string>();
            foreach(Book b in bookDetails.Values)
            {
                if (b.IssueDate == b.ReturnDate)
                {
                    list.Add(b.Name);
                }
            }
            return list;
        }
        static void Main(string[] args)
        {
            bookDetails.Add(1,new Book("M01", "THE STRANGER", "Adventure", "10/10/2023", "10/14/2023", 100));
            bookDetails.Add(2, new Book("M02", "Odyddey", "Adventure", "10/10/2023", "10/10/2023", 200));
            bookDetails.Add(3, new Book("M03", "The Hobbit", "Fantasy", "9/10/2023", "9/12/2023", 130));
            bookDetails.Add(4, new Book("M04", "War and Peace", "Historical", "10/10/2023", "10/11/2023", 100));
            bookDetails.Add(5, new Book("M05", "THE Alchemist", "Fantasy", "10/10/2023", "10/14/2023", 100));
 
            while (true)
            {
                Console.WriteLine("1. Group books by genre");
                Console.WriteLine("2.Update penalty amount");
                Console.WriteLine("3. Find same day return books");
                Console.WriteLine("4. Exit");
                Console.WriteLine("enter your choice");
                int choice = int.Parse(Console.ReadLine());
                Program p = new Program();
                if (choice == 1)
                {
                    SortedDictionary<string, List<Book>> dict;
 
                    dict = p.GroupBooksByGenre();
                    foreach (var de in dict)
                    {
                        string genre = de.Key;
                        List<Book> books = de.Value;
                        Console.WriteLine(genre);
                        foreach (Book book in books)
                        {
                            Console.WriteLine(book.Name);
                        }
                    }
 
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter the penalty amount");
                    double panalty = double.Parse(Console.ReadLine());
                    Dictionary<string, double> dict;
                    dict = p.UpdatePenaltyAmount(panalty);
                    foreach (var de in dict)
                    {
                        Console.WriteLine(de.Key + " " + de.Value);
                    }
 
                }
                else if (choice == 3)
                {
                    List<string> list = p.FindBooksNameWithSameDayReturn();
                    foreach (string s in list)
                    {
                        Console.WriteLine(s);
                    }
                }
                else
                {
                    break;
                }
            }
        }
    }
}
