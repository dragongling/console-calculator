using Xunit;

namespace CalculatorLibrary.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void ShouldCreateCalculator()
        {
            Calculator calculator = new();
            calculator.Finish();
        }

        [Fact]
        public void ShouldDoOperationCorrectly()
        {
            Calculator calc = new();

            // Addition
            Assert.Equal(5, calc.DoOperation(2.5, 2.5, "a"));
            Assert.Equal(-1, calc.DoOperation(2, -3, "a"));

            // Substraction
            Assert.Equal(2.2, calc.DoOperation(3.4, 1.2, "s"));
            Assert.Equal(2.2, calc.DoOperation(-1.2, -3.4, "s"));

            // Multiplication
            Assert.Equal(4, calc.DoOperation(2, 2, "m"));
            Assert.Equal(2, calc.DoOperation(4, 0.5, "m"));
            Assert.Equal(-1, calc.DoOperation(1, -1, "m"));
            Assert.Equal(1, calc.DoOperation(-1, -1, "m"));
            Assert.Equal(0, calc.DoOperation(1, 0, "m"));

            // Division
            Assert.Equal(2, calc.DoOperation(4, 2, "d"));
            Assert.Equal(4, calc.DoOperation(2, 0.5, "d"));
            Assert.Equal(-1, calc.DoOperation(1, -1, "d"));
            Assert.Equal(1, calc.DoOperation(-1, -1, "d"));
            Assert.Equal(double.NaN, calc.DoOperation(1, 0, "d"));

            // Unknown operation
            Assert.Equal(double.NaN, calc.DoOperation(1, 0, "default"));

            calc.Finish();
        }
    }
}
