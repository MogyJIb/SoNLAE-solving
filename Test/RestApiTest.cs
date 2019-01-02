using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoNLAE_solving.Logic.Models;
using SoNLAE_solving.Logic.Rest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class RestApiTest
    {
        [TestMethod]
        public void Test_request()
        {
            RestDTO expected = new RestDTO(0, 14, 10, new DoubleVector[]{
                    new DoubleVector(new double[]{ 1, 2, 3}),
                    new DoubleVector(new double[]{ 4, 5, 6})
                });

            RestDTO actual = new RestApi().CalculateService.Calculate(expected).Result;

            Assert.AreEqual(expected, actual);
        }
    }
    
}
