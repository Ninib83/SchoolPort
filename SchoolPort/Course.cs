using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Course : FakePerson
    {
        public Course(int id, string name, Teacher[] teacher, Class[] x, string startDate, string endDate) :base(id, name)
        {
            Teacher = teacher;
            Class = x;
            StartDate = startDate;
            EndDate = endDate;
        }
        public Teacher[] Teacher { get; set; }
        public Class[] Class { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }

    }
}
