using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.Rest;
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
        public string[] Addresses { get; set; }
        private int curr = 0;

        public GaussParallelMethod(MatrixInterface<Double> matrix, string[] addresses) : base(matrix)
        {
            name = "Gauss parallel";
            this.Addresses = addresses;
        }

        public GaussParallelMethod(MatrixInterface<Double> matrix) : this(matrix, new string[] { "http://127.0.0.1/" }) { }

        public GaussParallelMethod(Double[][] matrix) : this(new DoubleMatrix(matrix)) { }

        protected override void MakeTriangle(VectorInterface<Double>[] data)
        {
            List<LineSumThread> threads = new List<LineSumThread>();

            int step = getThreadsStep(Addresses.Length);
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
                        thread.Start(Addresses[curr]);
                        curr++;
                        if (curr >= Addresses.Length) curr = 0;

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

            RestApi restApi;
            Task<RestDTO> task;
            Thread thread;

            int startLineIndex;
            int endLineIndex;

            int addVectorIndex;
            VectorInterface<Double>[] vectors;

            public LineSumThread(int startLineIndex, int endLineIndex,
                                 int addVectorIndex, VectorInterface<Double>[] vectors)
            {
                this.startLineIndex = startLineIndex;
                this.endLineIndex = endLineIndex;
                this.addVectorIndex = addVectorIndex;
                this.vectors = vectors;
            }

            public void Start(string address)
            {
                restApi = new RestApi(address);
                thread = new Thread(StartThread);
                thread.Start();
            }

            private void StartThread()
            {
                var vectors = new DoubleVector[this.vectors.Length];
                for (int i = 0; i < vectors.Length; i++) vectors[i] = (DoubleVector)this.vectors[i];
                task = restApi.CalculateService.Calculate(new RestDTO(startLineIndex, endLineIndex, addVectorIndex, vectors));
                task.Wait();

                RestDTO restDTO =task.Result;
                for (int i = startLineIndex; i < endLineIndex && i < vectors.Length; i++)
                    for (int j = 0; j < vectors[i].Count; j++)
                        vectors[i][j] = restDTO.Vectors[i][j];
            }

            public void Join()
            {
                thread.Join();
            }
        }
    }
}
