using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public class GaussMethod : AbstractMethod
    {
        private DoubleVector solution;

        public GaussMethod(MatrixInterface<Double> matrix) : base(matrix, "Gauss") { }

        public GaussMethod(double[][] matrix) : this(new DoubleMatrix(matrix)) { }

        public override void Solve()
        {
            MatrixInterface<double> matrix = this.matrix.Copy();
            MakeTriangle(matrix.Vectors);
            solution = SOLAEMatrixUtil.solveTriangleMatrix(matrix as DoubleMatrix, SOLAEMatrixUtil.UPPER);
        }

        public override VectorInterface<double> GetSolution()
        {
            return solution;
        }

        protected virtual void MakeTriangle(VectorInterface<Double>[] data)
        {
            Double coefficient = 0.0;
            Double diagonalElement = 0.0;
            VectorInterface<Double> lineToAdd;

            for (int i = 0; i < data.Length - 1; i++)
            {
                diagonalElement = data[i][i];

                if (Double.IsInfinity(1 / diagonalElement)
                        || Double.IsNaN(1 / diagonalElement))
                    throw new ArithmeticException("Division by zero.");

                for (int j = i + 1; j < data.Length; j++)
                {
                    lineToAdd = data[i].Copy();
                    coefficient = -data[j][i] / diagonalElement;
                    lineToAdd.Mul(coefficient);
                    data[j].Add(lineToAdd);
                }
            }
        }
    }
}
