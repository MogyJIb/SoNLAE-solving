using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.statistic
{
    public interface Statistical
    {
        void MakeStatistic();

        Dictionary<int, long> GetWorkStatistic();
    }
}
