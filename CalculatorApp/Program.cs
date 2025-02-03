namespace CalculatorApp;

class Program
{
    static void Main(string[] args)
    {

        try
        {

            double num1;
            double num2;

            var calculator = new Calculator();

            Console.WriteLine("Enter the first number:");
            num1 = calculator.ConvertToDouble(Console.ReadLine());

            Console.WriteLine("Enter the second number:");
            num2 = calculator.ConvertToDouble(Console.ReadLine());

            Console.WriteLine("Enter the operation (add, subtract, multiply, divide):");

            string operation = Console.ReadLine()?.ToLower() ?? string.Empty;

            double result = calculator.PerformOperation(num1, num2, operation);

            Console.WriteLine($"The result is: {result}");
            Console.WriteLine("Calculation attempt finished.");
        }
        catch (FormatException ex)
        {
            Console.WriteLine("Invalid input. Please enter numeric values.");
            Console.WriteLine("Calculation attempt finished.");
            throw new FormatException(ex.Message);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Calculation attempt finished.");
            throw ex;
        }
        catch (InvalidOperationException ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine("Calculation attempt finished.");
            throw ex;
        }
    }
}