using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace ArchiveManagement
{
    public class Book
    {
        public string MemberID {  get; set; }
        public string Name { get; set; }
        public string Genre { get; set; }
        public string IssueDate {  get; set; }
        public string ReturnDate { get; set; }
 
        public double Penalty {  get; set; }
 
        public Book()
        {
        }
 
        public Book(string memberID, string name, string genre, string issueDate, string returnDate, double penalty)
        {
            MemberID = memberID;
            Name = name;
            Genre = genre;
            IssueDate = issueDate;
            ReturnDate = returnDate;
            Penalty = penalty;
        }
    }
}
