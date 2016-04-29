using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolPort
{
    class Administrator
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }
    }

    //class Administrator : FakePerson
    //{
    //    public Administrator(int id, string name, string password) :base(id, name)
    //    {
    //        Password = password;
    //    }
    //    public string Password { get; set; }
    //}
}
