using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.BookingLab
{
    public class Booking
    {
        public CourseName CourseName { get; set; }
        public int Duration { get; set; }
        public TimeOnly StartTime { get; set; }
        public DayOfWeek DayOfWeek { get; set; }

        public Booking()
        {

        }
        public Booking(CourseName subjectName, int duration, TimeOnly startHour, DayOfWeek dayOfWeek)
        {
            CourseName = subjectName;
            Duration = duration;
            StartTime = startHour;
            DayOfWeek = dayOfWeek;
        }
        public override string ToString()
        {
            return $"Subject: {CourseName} - Duration(h): {Duration} - StartHour: {StartTime} - DayOfWeek: {DayOfWeek.ToString()}";
        }
    }
}
