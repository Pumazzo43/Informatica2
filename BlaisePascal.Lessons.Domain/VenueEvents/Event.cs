using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.VenueEvents
{
    public class Event
    {
        public string Name { get; set; }
        public DateOnly Date { get; set; }
        public double TicketCost { get; set; }
        public List<EventTag> Tags { get; set; }

        public Event(string name, DateOnly date, double ticketCost, List<EventTag> tags)
        {
            Name = name;
            Date = date;
            TicketCost = ticketCost;
            Tags = new List<EventTag>();
            foreach (EventTag tag in tags)
            {
                Tags.Add(tag);
            }
        }
        public bool ContainsTag(EventTag tag)
        {
            foreach (EventTag currentTag in Tags)
            {
                if (currentTag == tag)
                {
                    return true;
                }
            }
            return false;
        }
        public bool ContainsTags(EventTag[] tags)
        {
            foreach (EventTag tag in tags)
            {
                if (!ContainsTag(tag))
                    return false;
            }
            return true;
        }

        public override string ToString()
        {
            string tag = string.Join(',', Tags);
            return $"Name: {Name}\nDate: {Date}\nTicketCost: {TicketCost}\n Tag: {tag}";
        }
    }
}
