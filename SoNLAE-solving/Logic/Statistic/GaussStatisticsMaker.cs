using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Statistic
{
    public class GaussStatisticsMaker : AbstractMethodStatistics
    {
        public GaussStatisticsMaker(MatrixInterface<Double> matrix, params int[] threadsCount) : base(matrix, threadsCount) { }

        protected override SOLAEParallelMethodInterface<double> GetMethod(MatrixInterface<double> matrix)
        {
            return new GaussParallelMethod(matrix);
        }
    }
}
