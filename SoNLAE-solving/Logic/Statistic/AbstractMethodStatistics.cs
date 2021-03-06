﻿using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.statistic;
using SoNLAE_solving.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Statistic
{
    public abstract class AbstractMethodStatistics : Statistical
    {
        private MatrixInterface<double> matrix;
        private int[] threadsCounts;
        private Dictionary<int, long> workStatistic;
        private string[] addresses;


        public AbstractMethodStatistics(MatrixInterface<double> matrix, params int[] threadsCount)
        {
            this.matrix = matrix;
            this.threadsCounts = threadsCount;
            workStatistic = new Dictionary<int, long>();
            addresses = FileHandler.ReadIPs();
            addresses = addresses.Take(1).ToArray();
        }

        protected abstract SOLAEParallelMethodInterface<double> GetMethod(MatrixInterface<double> matrix);

        public void MakeStatistic()
        {
            for (int i = 0; i < threadsCounts.Length; i++)
            {
                SOLAEParallelMethodInterface<Double> method =
                        GetMethod(matrix.Copy());
                method.Addresses = addresses.Take(threadsCounts[i] <= addresses.Length ? threadsCounts[i] : addresses.Length).ToArray();

                WorkTimeCounter workTimeCounter = new WorkTimeCounter(method.Solve);
                workTimeCounter.MakeWork();

                long workTime = workTimeCounter.GetWorkTime();
                workStatistic.Add(threadsCounts[i], workTime);
            }
        }

        public Dictionary<int, long> GetWorkStatistic()
        {
            return workStatistic;
        }
    }
}
