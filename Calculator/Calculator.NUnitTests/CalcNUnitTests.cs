using NUnit.Framework;

namespace Calculator.NUnitTests
{
    [TestFixture]
    public class CalcNUnitTests
    {
        [Test]
        public void Minus_6_minus_2_results_4()
        {
            Calc calc = new Calc();

            int result = calc.Minus(6, 2);

            Assert.AreEqual(4, result);
        }

        [Test]
        [TestCase(1, 2, -1)]
        [TestCase(10, 2, 8)]
        [TestCase(-19, 2, -21)]
        [TestCase(-19, -2, -17)]
        public void Minus(int a, int b, int expected)
        {
            Calc calc = new Calc();

            int result = calc.Minus(a, b);

            Assert.AreEqual(expected, result);
        }
    }
}