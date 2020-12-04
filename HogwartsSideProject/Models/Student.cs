using System;
using System.Collections.Generic;
using System.Text;

namespace HogwartsSideProject.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string HogwartsHouse { get; set; }
        public string TEClass { get; set; }
        public int TEClassID { get; set; }
        public int HogwartsHouseID { get; set; }

    }
}
