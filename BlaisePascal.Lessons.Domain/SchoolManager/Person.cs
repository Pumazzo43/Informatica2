using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.SchoolManager
{
    public abstract class Person
    {
        //Attributes
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Surname { get; set; } = string.Empty;

        public Person() { }

        public Person(int id, string name, string surname)
        {
            Id = id;
            Name = name;
            Surname = surname;
        }

        public virtual string SayHello()
        {
            return "Buongiorno!";
        }
        public virtual string CreateMail()
        {
            return Name + "." + Surname + "@ispascalcomandini.it";
        }
    }
}
