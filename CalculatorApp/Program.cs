
using Microsoft.Extensions.Logging;

namespace CalculatorApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using var loggerFactory = LoggerFactory.Create(builder => builder.AddConsole());

            ILogger logger = loggerFactory.CreateLogger<Program>();

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
                logger.LogInformation("Calculation attempt finished.");
            }
            catch (FormatException ex)
            {
                logger.LogError("Invalid input. Please enter numeric values.");
                logger.LogInformation("Calculation attempt finished.");
                throw new FormatException(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                logger.LogError(ex.Message);
                logger.LogInformation("Calculation attempt finished.");
                throw ex;
            }
            catch (InvalidOperationException ex)
            {
                logger.LogError(ex.Message);
                logger.LogInformation("Calculation attempt finished.");
                throw ex;
            }
        }
    }
}