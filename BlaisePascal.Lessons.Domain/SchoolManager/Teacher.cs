using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.SchoolManager
{
    public class Teacher : Person
    {
        private List<string> Subject { get; set; }

        public Teacher(int id, string name, string surname) : base(id, name, surname)
        {
            Subject = new List<string>();
        }

        public void AddSubject(string subject)
        {
            Subject.Add(subject);
        }

        public override string SayHello()
        {
            return base.SayHello() + " Oggi interrogo Dante su Dante A.";
        }

        public override string CreateMail()
        {
            return base.CreateMail();
        }
    }
}
