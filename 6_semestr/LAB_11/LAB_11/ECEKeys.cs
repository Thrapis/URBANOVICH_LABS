using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_11
{
    public struct ECEPublicKeys
    {
        public int p { get; private set; }
        public int a { get; private set; }
        public int b { get; private set; }
        public int q { get; private set; }
        public ECPoint G { get; private set; }
        public ECPoint Q { get; private set; }

        public ECEPublicKeys(int p, int a, int b, int q, ECPoint gp, ECPoint qp)
        {
            this.p = p;
            this.a = a;
            this.b = b;
            this.q = q;
            G = gp;
            Q = qp;
        }

        public override string ToString()
        {
            return $"p = {p}\r\na = {a}\r\nb = {b}\r\nq = {q}\r\nG = {G}\r\nQ = {Q}";
        }
    }

    public struct ECEPrivateKeys
    {
        public int p { get; private set; }
        public int a { get; private set; }
        public int b { get; private set; }
        public int q { get; private set; }
        public int d { get; private set; }
        public ECPoint G { get; private set; }

        public ECEPrivateKeys(int p, int a, int b, int q, int d, ECPoint gp)
        {
            this.p = p;
            this.a = a;
            this.b = b;
            this.q = q;
            this.d = d;
            this.G = gp;
        }

        public override string ToString()
        {
            return $"p = {p}\r\na = {a}\r\nb = {b}\r\nd = {d}\r\nG = {G}";
        }
    }
}
