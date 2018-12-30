using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public class GaussParallelMethod : GaussMethod, SOLAEParallelMethodInterface<Double> {
    private int threadCount;

    public GaussParallelMethod(MatrixInterface<Double> matrix, int threadCount): base(matrix)
    {
        name = "Gauss parallel";
        this.threadCount = threadCount;
    }

    public GaussParallelMethod(MatrixInterface<Double> matrix) : this(matrix, 5) { }

        public GaussParallelMethod(Double[][] matrix) : this(new DoubleMatrix(matrix)){ }


    protected override void MakeTriangle(VectorInterface<Double>[] data)
    {
        List<LineSumThread> threads = new List<LineSumThread>();

        int step = getThreadsStep(threadCount);
        int startInd, endInd;

        for (int i = 0; i < data.length; i++)
        {
            threads.clear();
            for (int j = 0; j < data.length / step; j++)
            {
                startInd = i + 1 + j * step;
                if (startInd < data.length)
                {
                    endInd = i + 1 + (j + 1) * step;
                    LineSumThread thread = new LineSumThread(startInd, endInd, i, data);
                    thread.start();

                    threads.add(thread);
                }
            }
            for (LineSumThread thread : threads)
                try
                {
                    thread.join();
                }
                catch (InterruptedException e)
                {
                    System.out.println("Thread 'LineSumThread' was" +
                            " interrupted with message: " + e.getMessage());
                }
        }
    }

    private int getThreadsStep(int threadCount)
    {
        if (threadCount > getMatrix().rowCount())
            return 1;

        return (int)Math.floor(1.0 * getMatrix().rowCount() / threadCount);
    }

    @Override
    public int getThreadCount()
    {
        return threadCount;
    }

    @Override
    public void setThreadCount(int count)
    {
        threadCount = count;
    }

    private class LineSumThread extends Thread
    {

        private int startLineIndex;
    private int endLineIndex;

    private int addVectorIndex;
    private VectorInterface<Double> vectors[];

    public LineSumThread(int startLineIndex, int endLineIndex,
                         int addVectorIndex, VectorInterface<Double>[] vectors)
    {
        this.startLineIndex = startLineIndex;
        this.endLineIndex = endLineIndex;
        this.addVectorIndex = addVectorIndex;
        this.vectors = vectors;
    }

    @Override
        public void run()
    {
        int i = addVectorIndex;
        Double diagonalElement = vectors[i].get(i);

        if (Double.isInfinite(1 / diagonalElement)
                || Double.isNaN(1 / diagonalElement))
            throw new ArithmeticException("Division by zero.");

        for (int j = startLineIndex; j < endLineIndex && j < vectors.length; j++)
        {
            VectorInterface<Double> lineToAdd = vectors[i].copy();
            Double coefficient = -vectors[j].get(i) / diagonalElement;

            lineToAdd.mul(coefficient);
            vectors[j].add(lineToAdd);
        }
    }
}
}
}
