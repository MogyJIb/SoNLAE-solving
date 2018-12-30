using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Utils
{
    public class Rand
    {
        private static int Int(int max)
        {
            return new Random().Next(max);
        }

        private static double Double(double max)
        {
            return new Random().NextDouble() * max;
        }

        private static DoubleVector DoubleVector(double max, int count)
        {
            double[] array = new RandomArray<double, double>(Double).Instance(max, count);
            return new DoubleVector(array);
        }

        private static DoubleMatrix DoubleMatrix(Double max, int rowCount, int columnCount)
        {
            double[][] array = new double[rowCount][];

            RandomArray<double, double> generator = new RandomArray<double, double>(Double);
            for (int i = 0; i < rowCount; i++)
            {
                array[i] = generator.Instance(max, columnCount);
            }

            return new DoubleMatrix(array);
        }


        public delegate T RandomFunctional<T, S>(S max);
        public delegate T RandomArrayFunctional<T, S>(S max, params int[] dimensionSizes);


        public class RandomArray<T, S>
        {
            private event RandomFunctional<T, S> generateRand;

            public RandomArray(RandomFunctional<T, S> randomFunctional)
            {
                this.generateRand += randomFunctional;
            }

            public T[] Instance(S max, int count)
            {
                T[] array = new T[count];
                for (int i = 0; i < count; i++)
                {
                    array[i] = generateRand(max);
                }
                return array;
            }
        }
    }
}
    

