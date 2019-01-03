using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoNLAE_solving.Logic.Methods;
using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class GaussParallelMethodTest
    {
        [TestMethod]
        public void Variables_3_matrix_solve()
        {
            VectorInterface<Double> expected = new DoubleVector(-2f / 11.0, 1f / 11.0, 5f / 11.0);

            GaussParallelMethod gaussMethod = new GaussParallelMethod(new Double[][]{new double[]{3.0, 2.0, 3.0, 1.0},
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
            GaussParallelMethod gaussMethod = new GaussParallelMethod(new Double[][]{new double[]{3.0, 2.0, 3.0},
                new double[]{4.0, 4.0, 3.0},
                new double[]{1.0, 4.0, 4.0}});
        }

        [TestMethod]
        public void Test1_file()
        {
            TestFile("test1");
        }

        [TestMethod]
        public void Test2_file()
        {
            TestFile("test2");
        }

        [TestMethod]
        public void Test3_file()
        {
            TestFile("test3");
        }

        [TestMethod]
        public void Test4_file()
        {
            TestFile("test4");
        }

        [TestMethod]
        public void Test5_file()
        {
            TestFile("test5");
        }


        private void TestFile(string testName)
        {
            VectorInterface<Double> expected = new DoubleVector(
                Parser.parseVector(FileHandler.Read("tests/" + testName + "/" + testName + ".des")));

            DoubleMatrix doubleMatrix = new DoubleMatrix(
                Parser.parseMatrix(FileHandler.Read("tests/" + testName + "/" + testName + ".A")));
            doubleMatrix.UpendColumn(new DoubleVector(
                Parser.parseVector(FileHandler.Read("tests/" + testName + "/" + testName + ".B"))));

            GaussParallelMethod gaussMethod = new GaussParallelMethod(doubleMatrix);
            gaussMethod.Solve();
            VectorInterface<Double> actual = gaussMethod.GetSolution();
            Assert.AreEqual(expected, actual);
        }
    }
}
