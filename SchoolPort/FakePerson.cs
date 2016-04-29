using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    abstract class FakePerson : HeadClass
    {
        public FakePerson(int id, string name) :base(id)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
