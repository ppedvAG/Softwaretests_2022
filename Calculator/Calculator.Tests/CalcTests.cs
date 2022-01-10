using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Calculator.Tests
{
    [TestClass]
    public class CalcTests
    {
        [TestMethod]
        public void Sum_2_and_3_results_5()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(2, 3);

            //Assert
            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Sum_0_and_0_results_0()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(0, 0);

            //Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        
        public void Sum_MAX_and_1_throws_OverflowException()
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            Assert.ThrowsException<OverflowException>(() => calc.Sum(int.MaxValue, 1));

        }

        [TestMethod]
        [TestCategory("ParameterTests")]
        [DataRow(0, 0, 0)]
        [DataRow(1, 2, 3)]
        [DataRow(120, 5, 125)]
        [DataRow(-0, -0, -0)]
        [DataRow(-3, -7, -10)]
        public void Sum_ParameterTests(int a, int b, int expected)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            int result = calc.Sum(a, b);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [DataRow(int.MaxValue, 1)]
        [DataRow(1, int.MaxValue)]
        [DataRow(-1, int.MinValue)]
        [DataRow(int.MinValue, -1)]
        [DataRow(int.MinValue + 1, -2)]
        [DataRow(int.MaxValue - 1, 2)]
        public void Sum_throws_OverflowException(int a, int b)
        {
            //Arrange
            Calc calc = new Calc();

            //Act
            Assert.ThrowsException<OverflowException>(() => calc.Sum(a, b));

        }
    }
}