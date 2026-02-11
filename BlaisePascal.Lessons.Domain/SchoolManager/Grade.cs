using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.SchoolManager
{
    public class Grade
    {
        //Attributes
        private double _value;
        private string _subject;
        private DateTime _date;

        //Constructor
        public Grade(double value, string subject)
        {
            _value = value;
            _subject = subject;
            _date = DateTime.Now;

        }
        public string getSubject() => _subject;
        public double getValue() => _value;

    }
}
