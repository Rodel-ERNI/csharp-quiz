using NUnit.Framework;

namespace CalculatorApp.UnitTests;

[TestFixture]
public class CalculatorTest
{
    private Calculator _calculator;

    [SetUp]
    public void Setup()
    {
        _calculator = new Calculator();
    }

    [Test]
    public void AddCalculation()
    {
        double result = _calculator.PerformOperation(5, 5, "add");
        Assert.That(result, Is.EqualTo(10));
    }

    [Test]
    public void SubtractCalculation()
    {
        double result = _calculator.PerformOperation(10, 5, "subtract");
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void MultiplyCalculation()
    {
        double result = _calculator.PerformOperation(5, 5, "multiply");
        Assert.That(result, Is.EqualTo(25));
    }

    [Test]
    public void DivideCalculation()
    {
        double result = _calculator.PerformOperation(50, 10, "divide");
        Assert.That(result, Is.EqualTo(5));
    }

    [Test]
    public void FormatThrowsFormatException()
    {
        var mockReadLineInput = "I am a string not a double";

        var ex = Assert.Throws<FormatException>(() =>
        {
            double num1 = _calculator.ConvertToDouble(mockReadLineInput);
        }
        );

        Assert.That(ex.Message, Is.EqualTo("Invalid input. Please enter numeric values."));
    }


    [Test]
    public void DivideByZeroThrowDivideByZeroException()
    {
        var ex = Assert.Throws<DivideByZeroException>(() =>
            _calculator.PerformOperation(10, 0, "divide")
        );

        Assert.That(ex.Message, Is.EqualTo("Cannot divide by zero"));
    }

    [Test]
    public void ThrowUnsupportedOperation()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
            _calculator.PerformOperation(10, 0, "modulo")
        );

        Assert.That(ex.Message, Is.EqualTo("An error occurred: The specified operation is not supported."));
    }

    [Test]
    public void SameZeroDivisionThrowsUnsupportedOperation()
    {
        var ex = Assert.Throws<InvalidOperationException>(() =>
            _calculator.PerformOperation(0, 0, "divide")
        );

        Assert.That(ex.Message, Is.EqualTo("Result is undefined."));
    }
}