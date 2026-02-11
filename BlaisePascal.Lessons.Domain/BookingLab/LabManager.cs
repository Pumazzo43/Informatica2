using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.BookingLab
{
    public class LabManager
    {
        public TimeOnly StartTime { get; private set; }
        public TimeOnly EndTime { get; private set; }
        public int TotalSlots { get; private set; }
        public DayOfWeek[] OpeningDays { get; private set; }
        public CourseName[,] Bookings { get; private set; }

        private enum Status
        {
            Booking,
            Hole
        }
        public LabManager(TimeOnly startTime, TimeOnly endTime, DayOfWeek[] openingDays)
        {
            if (startTime >= endTime) throw new ArgumentException("Start time must be before end time.");
            StartTime = startTime;
            EndTime = endTime;
            OpeningDays = openingDays;
            TotalSlots = EndTime.Hour - StartTime.Hour;
            Bookings = new CourseName[openingDays.Length, TotalSlots];
        }
        public void SetBooking(Booking newBooking)
        {
            int startBookingIdx = CheckBookingAvailability(newBooking);
            if (startBookingIdx == -1)
                throw new Exception("Invalid booking");
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            for (int i = startBookingIdx; i < startBookingIdx + newBooking.Duration; i++)
            {
                Bookings[dayIndex, i] = newBooking.CourseName;
            }

        }
        public int CheckBookingAvailability(Booking newBooking)
        {
            int dayIndex = GetDayIndex(newBooking.DayOfWeek);
            if (dayIndex == -1)
                return -1;

            int requestedDurationSlots = newBooking.Duration;
            int minStartSlotIndex = FromHourToIndex(newBooking.StartTime.Hour);
            int maxStartSlotIndex = TotalSlots - requestedDurationSlots;

            if (minStartSlotIndex >= TotalSlots || maxStartSlotIndex < 0)
                return -1;

            int startCandidate = minStartSlotIndex;
            bool bookingFound = false;
            while (startCandidate < maxStartSlotIndex && !bookingFound)
            {
                bool isSlotAvailable = true;
                int currentSlotIndex = startCandidate;
                while (currentSlotIndex < startCandidate + requestedDurationSlots && isSlotAvailable)
                {
                    if (Bookings[dayIndex, currentSlotIndex] != CourseName.Available)
                    {
                        isSlotAvailable = false;
                        startCandidate = currentSlotIndex;
                    }
                    if (isSlotAvailable)
                        currentSlotIndex++;
                }
                if (!isSlotAvailable)
                    startCandidate++;
                else
                    bookingFound = true;
            }
            return (bookingFound ? startCandidate : -1);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public Hole[][] HoleFilling()
        {
            Status status = Status.Booking;
            List<int> offset = new List<int>();
            List<int> length = new List<int>();
            Hole[][] Holes = new Hole[OpeningDays.Length][];
            int l = 0;
            for (int g = 0; g < OpeningDays.Length; g++)
            {
                status = Status.Booking;
                offset.Clear();
                length.Clear();
                for (int idx = 0; idx < TotalSlots; idx++)
                {
                    CourseName val = Bookings[g, idx];
                    switch (status)
                    {
                        case Status.Booking:
                            if (val == CourseName.Available)
                            {
                                //New Hole starts
                                l = 1;
                                offset.Add(idx);
                                status = Status.Hole;
                            }
                            else
                            {
                                //NOP
                            }
                            break;
                        case Status.Hole:
                            if (val == CourseName.Available)
                            {
                                l++;
                            }
                            else
                            {
                                length.Add(l);
                                status = Status.Booking;
                            }
                            break;
                        default:
                            throw new Exception("Invalid Status");
                    }
                }
                if (status == Status.Hole)
                {
                    length.Add(l);
                }
                Holes[g] = new Hole[offset.Count];
                for (int i = 0; i < offset.Count; i++)
                {
                    Holes[g][i] = new Hole() { Offset = offset[i], Lenght = length[i] };
                }
            }
            return Holes;


        }

        public bool SmartBooking(Booking newBooking)
        {
            Hole[][] Holes = HoleFilling();
            int[][] RemainingHours = new int[OpeningDays.Length][];

            for (int g = 0; g < OpeningDays.Length; g++)
            {
                RemainingHours[g] = new int[Holes[g].Length];
                for (int c = 0; c < RemainingHours[g].Length; c++)
                {
                    RemainingHours[g][c] = Holes[g][c].Lenght - newBooking.Duration;
                }
            }
            for (int g = 0; g < RemainingHours.Length; g++)
            {
                for (int c = 0; c < RemainingHours[g].Length; c++)
                {
                    if (RemainingHours[g][c] == 0)
                    {
                        for (int i = Holes[g][c].Offset; i < Holes[g][c].Offset + newBooking.Duration; i++)
                        {
                            Bookings[g, i] = newBooking.CourseName;
                        }
                        return true;
                    }
                }
            }

            int max = int.MinValue;
            int maxD = 0, maxH = 0;
            for (int g = 0; g < RemainingHours.Length; g++)
            {
                for (int c = 0; c < RemainingHours[g].Length; c++)
                {
                    if (RemainingHours[g][c] > 0 && RemainingHours[g][c] > max)
                    {
                        max = RemainingHours[g][c];
                        maxD = g;
                        maxH = c;
                    }
                }
            }

            if (max > 0)
            {
                for (int i = Holes[maxD][maxH].Offset; i < Holes[maxD][maxH].Offset + newBooking.Duration; i++)
                {
                    Bookings[maxD, i] = newBooking.CourseName;
                }
                return true;
            }

            return false;
        }

        private int GetDayIndex(DayOfWeek day)
        {
            for (int i = 0; i < OpeningDays.Length; i++)
            {
                if (OpeningDays[i] == day)
                {
                    return i;
                }
            }
            return -1;
        }

        public int FromIdxToHour(int idx)
        {
            return idx + StartTime.Hour;
        }

        public int FromHourToIndex(int hour)
        {
            return hour - StartTime.Hour;
        }
    }
}
