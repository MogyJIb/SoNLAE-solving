using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoNLAE_solving.Logic.Methods
{
    public class SOLAEMatrixUtil
    {
        public const bool LOW = true;
        public const bool UPPER = !LOW;

        public static bool isSolution(DoubleMatrix matrix, DoubleVector solution)
        {
            if (solution.Count != matrix.ColumnCount - 1)
                return false;

            Double rowSum = 0.0;

            for (int i = 0; i < matrix.RowCount; i++)
            {
                rowSum = 0.0;
                for (int j = 0; j < solution.Count; j++)
                {
                    rowSum += matrix[i, j] * solution[j];
                }
                rowSum -= matrix.Row(i).Last();

                if (rowSum > Constants.DELTA)
                    return false;
            }
            return true;
        }

        public static DoubleVector solveTriangleMatrix(DoubleMatrix matrix, bool isLow)
        {
            double[] result = new double[matrix.ColumnCount - 1];

            double rowSum = 0.0;
            int i = !isLow ? matrix.RowCount - 1 : 0;

            while ((!isLow && i >= 0) || (isLow && i < matrix.RowCount))
            {
                rowSum = 0.0;
                for (int j = 0; j < result.Length; j++)
                    rowSum += result[j] * matrix[i, j];
                rowSum = matrix.Row(i).Last() - rowSum;
                result[i] = matrix[i, i] == 0 ? 0 : rowSum / matrix[i, i];

                i = !isLow ? i - 1 : i + 1;
            }

            return new DoubleVector(result);
        }

        public static DoubleVector solveDiagonalMatrix(DoubleVector diagonal, DoubleVector values)
        {
            double[] result = new double[diagonal.Count];

            for (int i = 0; i < result.Length; i++)
                result[i] = values[i] / diagonal[i];

            return new DoubleVector(result);
        }

        public static void makeSymmetric(DoubleMatrix matrix)
        {
            int length = (matrix.ColumnCount < matrix.RowCount)
                    ? matrix.ColumnCount
                    : matrix.RowCount;

            for (int i = 0; i < length; i++)
            {
                for (int j = 0; j < length; j++)
                {
                    if (i == j) continue;

                    double value = matrix[i, j];
                    matrix[j, i] = value;
                }
            }
        }
    }
}
