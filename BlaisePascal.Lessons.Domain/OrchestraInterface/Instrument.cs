using BlaisePascal.Lessons.Domain.OrchestraInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    public abstract class Instrument : ISoundMaker
    {
        public string Name { get; set; }
        protected Instrument(string name)
        {
            Name = name;
        }

        public abstract string Play();
    }
}
