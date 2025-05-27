using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    // [HttpGet("Cards")]
    // public IActionResult GetCustomerCards(string documentNumber)
    // {
    //     var cardService = new CardService();
    //     var customerCards = cardService.GetCustomerCards(documentNumber);

    //     if (!customerCards.Any())
    //     {
    //         return NotFound();
    //     }

    //     return Ok(customerCards);
    // }

    // [HttpPost]
    // public Customer CreateCustomer(
    //     string fullName,
    //     int birthYear,
    //     int birthMonth,
    //     int birthDay,
    //     string documentNumber
    // )
    // {
    //     var customerService = new CustomerService();
    //     return customerService.CreateCustomer(fullName, birthYear, birthMonth, birthDay, documentNumber);
    // }
}