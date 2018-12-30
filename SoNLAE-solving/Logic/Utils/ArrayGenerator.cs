using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Utils
{
    public class ArrayGenerator
    {
        public static double[] GetDouble(int count)
        {
            double[] array = new double[count];
            for (int i = 0; i < count; i++)
            {
                array[i] = 0.0;
            }
            return array;
        }
    }
}
