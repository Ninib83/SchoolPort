using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Teacher : RealPerson
    {
        public Teacher(int id, string firstname, string lastname, Course course) : base(id, firstname, lastname)
        {
            Course = course;
        }
        public Course Course { get; set; }
    }
}
