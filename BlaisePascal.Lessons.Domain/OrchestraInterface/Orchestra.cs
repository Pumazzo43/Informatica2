using BlaisePascal.Lessons.Domain.OrchestraInterface;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class Orchestra
    {
        List<ISoundMaker> SoundMakers;

        public Orchestra()
        {
            SoundMakers = new List<ISoundMaker>();
        }

        public void addDrum(Drum d)
        {
            SoundMakers.Add(d);
            SoundMakers.Add(new SoundMaker("nome", 12));
        }
        public void addPiano(Piano p)
        {
            SoundMakers.Add(p);
        }
        public string PlayAll()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Instrument i in SoundMakers)
            {
                sb.AppendLine(i.Play());
            }
            return sb.ToString();
        }
    }
}
