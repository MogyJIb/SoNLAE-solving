using Microsoft.VisualStudio.TestTools.UnitTesting;
using SoNLAE_solving.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    [TestClass]
    public class RestDtoTest
    {
        [TestMethod]
        public void Test_serialization()
        {
            RestDTO expected = new RestDTO(0, 14, 10, new DoubleVector[]{
                new DoubleVector(new double[]{ 1, 2, 3}),
                new DoubleVector(new double[]{ 4, 5, 6})
            });

            string restDTOstring = RestDTO.Serialize(expected);

            RestDTO actual = RestDTO.Deserialize(restDTOstring);

            Assert.AreEqual(expected, actual);
        }
    }
}
