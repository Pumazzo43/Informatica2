using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.VenueEvents
{
    public class Venue
    {
        public string Name { get; set; }
        public List<Event> Events { get; set; }

        public Venue(string name)
        {
            Name = name;
            Events = new List<Event>();
        }
        public void AddEvent(string name, DateOnly day, double cost, EventTag[] tags)
        {
            Event newEvent = new Event(name, day, cost, tags.ToList<EventTag>());
            Events.Add(newEvent);
        }
        public Event[] MostExpensiveEvents()
        {
            double maxCost = 0.0;
            foreach (Event e in Events)
            {
                if (e.TicketCost > maxCost) maxCost = e.TicketCost;
            }

            List<Event> expensiveList = new List<Event>();
            foreach (Event e in Events)
            {
                if (e.TicketCost == maxCost) expensiveList.Add(e);
            }
            return expensiveList.ToArray();
        }

        //public EventTag[] MostPopularTags()
        //{
        //    EventTag[] uniqueTags = GetUniqueTagsFromEvents();
        //    int[] counts = new int[uniqueTags.Length];

        //    for (int i = 0; i < uniqueTags.Length; i++)
        //    {
        //        foreach (Event ev in Events)
        //        {
        //            if (ev.ContainsTag(uniqueTags[i]))
        //            {
        //                counts[i]++;
        //            }
        //        }
        //    }

        //    int maxCount = 0;
        //    foreach (int c in counts)
        //    {
        //        if (c > maxCount) maxCount = c;
        //    }

        //    List<EventTag> result = new List<EventTag>();
        //    for (int i = 0; i < counts.Length; i++)
        //    {
        //        if (counts[i] == maxCount) result.Add(uniqueTags[i]);
        //    }
        //    return result.ToArray();
        //}
        public EventTag[] MostPopularTags()
        {
            Dictionary<EventTag, int> CountingTags = new Dictionary<EventTag, int>();
            foreach (Event e in Events)
            {
                foreach (EventTag et in e.Tags)
                {
                    if (!CountingTags.ContainsKey(et))
                    {
                        CountingTags.Add(et, 0);
                    }
                    else
                    {
                        CountingTags[et]++;
                    }
                }
            }
            return null;
        }

        public Event[] CompatibleEvents(EventTag[] tags)
        {
            List<Event> matches = new List<Event>();
            foreach (Event e in Events)
            {
                if (e.ContainsTags(tags)) matches.Add(e);
            }
            return matches.ToArray();
        }


        private EventTag[] GetUniqueTagsFromEvents()
        {
            List<EventTag> uniqueList = new List<EventTag>();
            foreach (Event ev in Events)
            {
                foreach (EventTag t in ev.Tags)
                {
                    bool alreadyAdded = false;
                    foreach (EventTag added in uniqueList)
                    {
                        if (added == t) { alreadyAdded = true; }
                    }
                    if (!alreadyAdded) uniqueList.Add(t);
                }
            }
            return uniqueList.ToArray();
        }

        public int[,] GenerateTagEventMatrix()
        {
            EventTag[] tagList = GetUniqueTagsFromEvents();
            int[,] matrix = new int[tagList.Length, Events.Count];

            for (int i = 0; i < tagList.Length; i++)
            {
                for (int j = 0; j < Events.Count; j++)
                {
                    if (Events[j].ContainsTag(tagList[i]))
                    {
                        matrix[i, j] = 1;
                    }
                    else
                    {
                        matrix[i, j] = 0;
                    }
                }
            }
            return matrix;
        }

        public Event[][] GenerateJaggedTagEvents()
        {
            EventTag[] tagList = GetUniqueTagsFromEvents();
            Event[][] jagged = new Event[tagList.Length][];

            for (int i = 0; i < tagList.Length; i++)
            {
                List<Event> associatedEvents = new List<Event>();
                foreach (Event ev in Events)
                {
                    if (ev.ContainsTag(tagList[i]))
                    {
                        associatedEvents.Add(ev);
                    }
                }
                jagged[i] = associatedEvents.ToArray();
            }
            return jagged;
        }
    }
}
