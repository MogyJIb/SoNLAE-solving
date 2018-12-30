using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public class GaussParallelMethod : GaussMethod, SOLAEParallelMethodInterface<Double>
    {
        public int ThreadCount { get; set; }

        public GaussParallelMethod(MatrixInterface<Double> matrix, int threadCount) : base(matrix)
        {
            name = "Gauss parallel";
            this.ThreadCount = threadCount;
        }

        public GaussParallelMethod(MatrixInterface<Double> matrix) : this(matrix, 5) { }

        public GaussParallelMethod(Double[][] matrix) : this(new DoubleMatrix(matrix)) { }


        protected override void MakeTriangle(VectorInterface<Double>[] data)
        {
            List<LineSumThread> threads = new List<LineSumThread>();

            int step = getThreadsStep(ThreadCount);
            int startInd, endInd;

            for (int i = 0; i < data.Length; i++)
            {
                threads.Clear();
                for (int j = 0; j < data.Length / step; j++)
                {
                    startInd = i + 1 + j * step;
                    if (startInd < data.Length)
                    {
                        endInd = i + 1 + (j + 1) * step;
                        LineSumThread thread = new LineSumThread(startInd, endInd, i, data);
                        thread.Start();

                        threads.Add(thread);
                    }
                }
                foreach (LineSumThread thread in threads)
                    thread.Join();
            }
        }

        private int getThreadsStep(int threadCount)
        {
            if (threadCount > matrix.RowCount)
                return 1;

            return (int)Math.Floor(1.0 * matrix.RowCount / threadCount);
        }

        public int getThreadCount()
        {
            throw new NotImplementedException();
        }

        public void setThreadCount(int count)
        {
            throw new NotImplementedException();
        }

        private class LineSumThread
        {

            private Thread thread { get; set; }

            private int startLineIndex;
            private int endLineIndex;

            private int addVectorIndex;
            private VectorInterface<Double>[] vectors;

            public LineSumThread(int startLineIndex, int endLineIndex,
                                 int addVectorIndex, VectorInterface<Double>[] vectors)
            {
                this.startLineIndex = startLineIndex;
                this.endLineIndex = endLineIndex;
                this.addVectorIndex = addVectorIndex;
                this.vectors = vectors;
                thread = new Thread(run);
            }

            public void Start()
            {
                thread.Start();
            }

            public void Join()
            {
                thread.Join();
            }

            private void run()
            {
                int i = addVectorIndex;
                Double diagonalElement = vectors[i][i];

                if (Double.IsInfinity(1 / diagonalElement)
                        || Double.IsNaN(1 / diagonalElement))
                    throw new ArithmeticException("Division by zero.");

                for (int j = startLineIndex; j < endLineIndex && j < vectors.Length; j++)
                {
                    VectorInterface<Double> lineToAdd = vectors[i].Copy();
                    Double coefficient = -vectors[j][i] / diagonalElement;

                    lineToAdd.Mul(coefficient);
                    vectors[j].Add(lineToAdd);
                }
            }
        }
    }
}
