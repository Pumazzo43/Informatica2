using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
}