using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Utils
{
    public class Parser
    {
        public static Dictionary<int, long> parseStatistic(string data)
        {
            Dictionary<int, long> statistic = new Dictionary<int, long>();

            try
            {
                string[] lines = data.Trim().Split('\n');
                foreach (string line in lines)
                {
                    string[] values = line.Trim().Split(' ');
                    int threadsCount = int.Parse(values[0]);
                    long time = long.Parse(values[1].Trim());

                    statistic.Add(threadsCount, time);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Wrong file format.\n" + e.Message);
            }
            return statistic;
        }

        public static DoubleMatrix parseMatrix(String data)
        {
            string[] lines = data.Trim().Split('\n');
            double[][] matrix = new double[lines.Length][];

            for (int i = 0; i < lines.Length; i++)
            {
                string[] values = lines[i].Trim().Split(' ');
                matrix[i] = new double[values.Length];

                for (int j = 0; j < values.Length; j++)
                {
                    matrix[i][j] = Double.Parse(values[j].Trim());
                }
            }

            return new DoubleMatrix(matrix);
        }

        public interface Parsable<T>
        {
            T parse(String data);
        }
    }
}
