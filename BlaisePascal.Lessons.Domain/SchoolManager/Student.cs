using System.Diagnostics.Metrics;

namespace BlaisePascal.Lessons.Domain.SchoolManager
{
    public class Student : Person
    {
        public string Class { get; set; }
        List<Grade> Grades { get; set; }
        HashSet<string> _subjects;

        public Student()
        {

        }
        public Student(int id, string name, string surname, string c) : base(id, name, surname)
        {
            Class = c;
            Grades = new List<Grade>();
            _subjects = new HashSet<string>();
        }

        //public new string SayHello()
        //{
        //    return base.SayHello() + " Ciao prof!!";
        //}
        public override string SayHello()
        {
            return base.SayHello() + " Ciao prof!!";
        }
        public void addGrade(double value, string subject)
        {
            Grades.Add(new Grade(value, subject));
        }


        private double getAverage(string subject)
        {
            double sum = 0;
            int counter = 0;
            for (int i = 0; i < Grades.Count; i++)
            {
                if (Grades[i].getSubject() == subject)
                {
                    sum += Grades[i].getValue();
                    counter++;
                }
            }
            return sum / counter;
        }
        public string getBestSubject()
        {
            double bestAverage = double.MinValue;
            string bestSubject = string.Empty;
            double average = 0.0;
            for (int i = 0; i < Grades.Count; i++)
            {
                _subjects.Add(Grades[i].getSubject());
            }
            for (int i = 0; i < _subjects.Count; i++)
            {
                average = getAverage(_subjects.ElementAt(i));
                if (average > bestAverage)
                {
                    bestAverage = average;
                    bestSubject = _subjects.ElementAt(i);
                }
            }

            return bestSubject;


        }

        public override string CreateMail()
        {
            return base.CreateMail().Replace("@", ".stud@");
        }

        //public int getLongestInsufficensiesStreak()
        //{
        //    int longestStreak = 0;
        //    int insufficensiesStreak = 0;
        //    for(int i = 0; i< _grades.Count;i++)
        //    {
        //        if(_grades[i].getValue  )
        //    }
        //}





    }
}
