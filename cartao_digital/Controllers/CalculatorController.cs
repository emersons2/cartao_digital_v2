using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Provê ferramentas para cálculo matemático simples.
/// </summary>
[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
   private readonly CustomerService _customerService;

   public CalculatorController(CustomerService customerService)
   {
      _customerService = customerService;
   }

   /// <summary>
   /// Realiza operação matemática de acordo com o tipo de operação informado e os parâmetros desejados.
   /// </summary>
   /// <param name="operation">Informe a operação desejada: [soma, subtração, multiplicação, divisão]</param>
   /// <param name="num1">Informe o primeiro valor da operação</param>
   /// <param name="num2">Informe o segundo valor da operação</param>
   /// <returns></returns>
   [HttpGet("Calculate")]
   public string Calculate(string operation, double num1, double num2)
   {
      var alert = "Tome cuidado com números negativos";
      var result = $"Resultado da {operation}: ";

      switch (operation)
      {
         case "soma":
            result = (num1 + num2).ToString();
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

   /// <summary>
   /// Realiza a soma dos dois valores informados.
   /// </summary>
   /// <param name="value1"></param>
   /// <param name="value2"></param>
   /// <returns></returns>
   public static long Sum(long value1, long value2)
   {
      var result = value1 + value2;
      return result;
   }

   public static double Subtract(double num1, double num2)
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