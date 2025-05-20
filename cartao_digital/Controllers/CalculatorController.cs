using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
   private readonly CustomerService _customerService;
    public CalculatorController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("Calculate")]
   public string Calculate(string operation, double num1, double num2)
   {
      var alert = "Tome cuidado com números negativos";
      var result = $"Resultado da {operation}: ";

      switch (operation)
      {
         case "soma":
            result += Sum(num1, num2).ToString();
            break;
         case "subtracao":
         case "subtração":
            var substractResult = Subtract(num1, num2);
            if (substractResult < 0)
            {
               result += substractResult.ToString() + " " + alert;
            }
            else
            {
               result += substractResult.ToString();
            }
            break;
         case "multiplicacao":
         case "multiplicação":
            result += Multiply(num1, num2).ToString();
            break;
         case "divisao":
         case "divisão":
            result += Divide(num1, num2).ToString();
            break;
         default:
            return $"Operação {operation} não reconhecida.";
      }

      return result;
   }

   private double Sum(double value1, double value2)
   {
        var result = value1 + value2;
        return result;
   }

   private double Subtract(double num1, double num2)
   {
        var result = num1 - num2;
        return result;
   }

   private double Multiply(double num1, double num2)
   {
        var result = num1 * num2;
        return result;
   }

   private double Divide(double num1, double num2)
   {
        if (num2 == 0)
        {
            throw new ArgumentException("Division by zero is not allowed.");
        }
        var result = num1 / num2;
        return result;
   }
}