using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Teacher  Teacher { get; set; }
        public Class Class { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
