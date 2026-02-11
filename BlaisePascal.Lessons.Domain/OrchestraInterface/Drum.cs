using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class Drum : Instrument
    {
        public Drum() : base("drum")
        {

        }

        public override string Play()
        {
            return "tuttumcia";
        }
    }
}
