using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class MatrixUtilTest
    {
        [TestMethod]
        public void Vector_is_solution_return_true()
        {
            DoubleVector solution = new DoubleVector(-2 / 11.0, 1 / 11.0, 5 / 11.0);

            DoubleMatrix matrix = new DoubleMatrix(new Double[][]{new Double[]{3.0, 2.0, 3.0, 1.0},
                new Double[]{4.0, 4.0, 3.0, 1.0},
                new Double[]{1.0, 4.0, 4.0, 2.0}});

            Assert.IsTrue(SOLAEMatrixUtil.isSolution(matrix, solution));
        }

        [TestMethod]
        public void Vector_is_solution_return_false()
        {
            DoubleVector solution = new DoubleVector(1.0, 1.0, 1.0);

            DoubleMatrix matrix = new DoubleMatrix(new Double[][]{new Double[]{3.0, 2.0, 3.0, 1.0},
                new Double[]{4.0, 4.0, 3.0, 1.0},
                new Double[]{1.0, 4.0, 4.0, 2.0}});

            Assert.IsFalse(SOLAEMatrixUtil.isSolution(matrix, solution));
        }

        [TestMethod]
        public void Make_matrix_symmetric()
        {
            DoubleMatrix expected = new DoubleMatrix(new Double[][]{
               new Double[] {3.0, 2.0, 3.0, 1.0},
                new Double[]{2.0, 4.0, 3.0, 1.0},
                new Double[]{3.0, 3.0, 4.0, 2.0}});

            DoubleMatrix actual = new DoubleMatrix(new Double[][]{
                new Double[]{3.0, 2.0, 3.0, 1.0},
                new Double[]{4.0, 4.0, 3.0, 1.0},
                new Double[]{1.0, 4.0, 4.0, 2.0}});
            SOLAEMatrixUtil.makeSymmetric(actual);

            Assert.AreEqual(expected, actual);
        }
    }
}
