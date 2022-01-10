using Xunit;

namespace Calculator.xUnitTests
{
    public class CalcXUnitTests
    {
        [Fact]
        public void Minus_6_minus_2_results_4()
        {
            Calc calc = new Calc();

            int result = calc.Minus(6, 2);

            Assert.Equal(4, result);
        }

        [Theory]
        [InlineData(1, 2, -1)]
        [InlineData(10, 2, 8)]
        [InlineData(-19, 2, -21)]
        [InlineData(-19, -2, -17)]
        public void Minus(int a, int b, int expected)
        {
            Calc calc = new Calc();

            int result = calc.Minus(a, b);

            Assert.Equal(expected, result);
        }
    }
}