namespace cartao_digital.Tests;

public class CalculatorTests
{
    [Fact]
    public void TestSum()
    {
        var result = CalculatorController.Sum(1, 1);
        Assert.Equal(2, result);
    }

    [Theory]
    [InlineData(1, 1, 2)]
    [InlineData(5, 6, 11)]
    [InlineData(11, 22, 33)]
    [InlineData(56, 45, 101)]
    [InlineData(50000000000, 150000000000, 200000000000)]
    public void TestSum2(long num1, long num2, long expectedResult)
    {
        var result = CalculatorController.Sum(num1, num2);
        Assert.Equal(expectedResult, result);
    }

    [Theory]
    [InlineData(1, 1, 0)]
    [InlineData(1, 2, -1)]
    [InlineData(2, 1, 1)]
    [InlineData(10, 10, 0)]
    public void TestSubstract(int num1, int num2, int expectedResult)
    {
        var result = CalculatorController.Subtract(num1, num2);
        Assert.Equal(expectedResult, result);
    }
}