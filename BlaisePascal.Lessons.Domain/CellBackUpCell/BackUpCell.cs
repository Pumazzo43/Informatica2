using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlaisePascal.Lessons.Domain.CellBackUpCell
{
    public class BackUpCell : Cell
    {
        private int oldVal;
        public BackUpCell(int v) : base(v)
        {
            oldVal = v;
        }
        public BackUpCell() : base()
        {
            oldVal = 0;
        }
        public override void setVal(int v)
        {
            oldVal = getVal();
            base.setVal(v);
        }
        public override void clear()
        {
            oldVal = getVal();
            base.clear();
        }
        public void restore()
        {
            int tmp = getVal();
            base.setVal(oldVal);
            oldVal = tmp;
        }
    }
}
