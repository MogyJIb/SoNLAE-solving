using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;

namespace Test
{
    [TestClass]
    public class GaussMethodTest
    {
        [TestMethod]
        public void Variables_3_matrix_solve()
        {
            VectorInterface<Double> expected = new DoubleVector(-2f / 11.0, 1f / 11.0, 5f / 11.0);

            GaussMethod gaussMethod = new GaussMethod(new Double[][]{new double[]{3.0, 2.0, 3.0, 1.0},
                new double[]{4.0, 4.0, 3.0, 1.0},
                new double[]{1.0, 4.0, 4.0, 2.0}});
            gaussMethod.Solve();
            VectorInterface<Double> actual = gaussMethod.GetSolution();
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Illegal_matrix_initialize_throw_exception()
        {
            GaussMethod gaussMethod = new GaussMethod(new Double[][]{new double[]{3.0, 2.0, 3.0},
                new double[]{4.0, 4.0, 3.0},
                new double[]{1.0, 4.0, 4.0}});
        }
    }
}
