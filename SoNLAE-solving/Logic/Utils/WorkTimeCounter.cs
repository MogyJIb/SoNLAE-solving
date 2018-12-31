using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Utils
{
    public class WorkTimeCounter
    {
        private event Workable work;
        private long workTime;

        public WorkTimeCounter(Workable workable)
        {
            work += workable;
        }

        public void MakeWork()
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();
            work();
            watch.Stop();
            this.workTime = watch.ElapsedMilliseconds;
        }

        public long GetWorkTime()
        {
            return this.workTime;
        }

       
        public override string ToString()
        {
            return Converter.NanoSecondsToString(workTime);
        }
    }

}
