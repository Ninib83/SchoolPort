using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Student : RealPerson
    {
        public Student(int id, string firstname, string lastname, int securityNr, Class x) : base(id, firstname, lastname)
        {
            SecurityNr = securityNr;
            Class = x;
        }
        public int SecurityNr { get; set; }
        public Class Class { get; set; }
    }
}
