public class CalculatorTests
{
    [Theory]
    [InlineData(5, 5, 10)]
    [InlineData(5, -5, 0)]
    [InlineData(-5, 5, 0)]
    [InlineData(-5, -5, 0)]
    public void AddTests(int i1, int i2, int expected)
    {
        var calc = new Calculator<int>();
        var result = calc.Add(i1, i2);
    }
}