using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.OrchestraInterface
{
    internal class SoundMaker : Person, ISoundMaker
    {
        public SoundMaker(string name, int age) : base(name, age)
        {

        }

        public string Play()
        {
            return "buabua";
        }
    }
}
