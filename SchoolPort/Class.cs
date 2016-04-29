using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Class : FakePerson
    {
        public Class(int id, string name, Student[] student) :base(id, name)
        {
            Student = student;
        }
        public Student[] Student { get; set; }
    }
}
