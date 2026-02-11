using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class Piano : Instrument
    {
        public Piano() : base("piano")
        {

        }

        public override string Play()
        {
            return "blenblen";
        }
    }
}
