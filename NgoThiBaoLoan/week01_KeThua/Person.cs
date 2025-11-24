using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week01_KeThua
{
    internal class Person
    {
        public string Id { get; set; }
        public string fullName { get; set; }
        public Person() { }

        public Person(string Id, string fullName)
        {
            this.Id = Id;
            this.fullName = fullName;
        }
    }
}
