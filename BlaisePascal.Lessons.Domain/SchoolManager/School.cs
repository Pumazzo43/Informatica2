using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.SchoolManager
{
    public class School
    {
        private List<Person> People { get; set; }

        public School()
        {
            People = new List<Person>();
        }
        public void AddStudent(string name, string surname, string c)
        {
            People.Add(new Student(People.Count + 1, name, surname, c));
            //People.Add(new Student() { Id = People.Count + 1, Name = name, Surname = surname, Class = c });
        }
        public void AddTeacher(string name, string surname)
        {
            People.Add(new Teacher(People.Count + 1, name, surname));
        }
        public string AllGreeting()
        {
            string msg = string.Empty;
            //for(int i=0; i<People.Count; i++)
            //{
            //    msg += People[i].SayHello() + "\n";
            //}
            //Alternativa 1
            //foreach(Person p in People)
            //{
            //    msg += p.SayHello() + "\n";
            //}
            //return msg;
            //Alternativa 2
            StringBuilder sb = new StringBuilder();
            foreach (Person p in People)
            {
                sb.AppendLine(p.SayHello());
            }
            return sb.ToString();
        }
        public bool AddSubjectByTeacherId(int teacherId, string subject)
        {
            bool found = false;
            foreach (Person p in People)
            {
                if (p is Teacher)
                {
                    if (p.Id == teacherId)
                    {
                        ((Teacher)p).AddSubject(subject);
                        found = true;
                    }
                }
            }
            return found;
        }
    }
}
