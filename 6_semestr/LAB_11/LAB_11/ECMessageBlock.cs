using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECMessageBlock
    {
        public ECPoint C1 { get; private set; }
        public ECPoint C2 { get; private set; }

        public ECMessageBlock(ECPoint c1, ECPoint c2)
        {
            C1 = c1;
            C2 = c2;
        }

        public override string ToString()
        {
            return $"[{C1};{C2}]";
        }
    }
}
