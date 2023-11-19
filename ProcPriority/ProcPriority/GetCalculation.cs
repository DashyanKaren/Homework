using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProcPriority
{
    internal class GetCalculation
    {
        public long Fiirst { get; set; }
        public long Second { get; set; }

        public void MultiplyAndDivide(int x, int y, int count)
        {
            for (int i = 0; i < count*100000; i++)
            {
                this.Fiirst = x * y;
            }
            for (int i = 0; i < count; i++)
            {
                this.Second = x / y;
            }
        }
    }
}
