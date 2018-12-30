using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Utils
{
    public class Converter
    {
        public static String NanoSecondsToString(long nanoSeconds)
        {
            StringBuilder result = new StringBuilder("");
            if (nanoSeconds == 0)
                return "0";

            long sec = nanoSeconds / 1000000000,
                    ml_sec = (nanoSeconds / 1000000) % 1000,
                    mk_sec = (nanoSeconds / 1000) % 1000,
                    n_sec = (nanoSeconds) % 1000;


            result.Append(String.Format("%4ds %4dmls",
                    sec, ml_sec));
            return result.ToString();
        }

        public static Double NanoSecondsToSeconds(long nanoSeconds, int accuracy)
        {
            return Math.Round(nanoSeconds / 1000000.0, accuracy);
        }

        public static String ThreadsCountToString(int[] threadsCounts)
        {
            if (threadsCounts.Length == 0)
                return "";

            StringBuilder result = new StringBuilder("");
            for (int i = 0; i < threadsCounts.Length; i++)
            {
                result.Append(threadsCounts[i]);
                result.Append(" ");
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }

        public static String StatisticsToString(Dictionary<int, long> statistics)
        {
            if (statistics.Count == 0)
                return "";

            StringBuilder result = new StringBuilder("");
            foreach (var entry in statistics)
            {
                result.Append(entry.Key);
                result.Append(" ");
                result.Append(entry.Value);
                result.Append('\n');
            }
            result.Remove(result.Length - 1, 1);
            return result.ToString();
        }
    }
}
