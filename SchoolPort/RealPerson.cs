using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    abstract class RealPerson : HeadClass
    {
        public RealPerson(int id, string firstname, string lastname) : base(id)
        {
            FirstName = firstname;
            LastName = lastname;
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
