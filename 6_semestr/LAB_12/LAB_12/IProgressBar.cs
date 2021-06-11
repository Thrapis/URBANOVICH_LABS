using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB_12
{
    public interface IProgressBar
    {
        void ProgressChanged(double progress, double from);
        void ProgressChanged(int progressPercents);
    }
}
