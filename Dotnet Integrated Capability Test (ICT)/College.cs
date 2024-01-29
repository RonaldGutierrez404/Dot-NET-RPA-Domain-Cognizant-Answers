using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Net_App1
{
    public class College
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public int StudentsCount { get; set; }

        public College() { }

        public College(int id, string name, string location, int studentsCount)
        {
            Id = id;
            Name = name;
            Location = location;
            StudentsCount = studentsCount;
        }
    }
}
