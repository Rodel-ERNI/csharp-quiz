namespace CalculatorApp;

public class Calculator
{
    public double PerformOperation(double num1, double num2, string operation)
    {
        switch (operation)
        {
            case "add":
                return num1 + num2;
            case "subtract":
                return num1 - num2;
            case "multiply":
                return num1 * num2;
            case "divide":
                if (num1 > 0 && num2 == 0) throw new DivideByZeroException("Cannot divide by zero");
                if (num1 == 0 && num2 == 0) throw new InvalidOperationException("Result is undefined.");

                return num1 / num2;
            default:
                throw new InvalidOperationException("An error occurred: The specified operation is not supported.");
        }
    }

    public bool ValidateInput(double value)
    {
        return value is double || value is int;
    }

    public double ConvertToDouble(string? value)
    {
        try
        {
            return Convert.ToDouble(value);
        }
        catch (FormatException ex)
        {
            throw new FormatException("Invalid input. Please enter numeric values.");
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }
}