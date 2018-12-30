using SoNLAE_solving.Logic.Methods;
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


    public AbstractMethodStatistics(MatrixInterface<double> matrix, params int[] threadsCount)
    {
        this.matrix = matrix;
        this.threadsCounts = threadsCount;
        workStatistic = new Dictionary<int, long>();
    }

    protected abstract SOLAEParallelMethodInterface<double> GetMethod(MatrixInterface<double> matrix);

    public void MakeStatistic()
    {
        for (int i = 0; i < threadsCounts.Length; i++)
        {
            SOLAEParallelMethodInterface<Double> method =
                    GetMethod(matrix.Copy());
            method.ThreadCount = (threadsCounts[i]);

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
