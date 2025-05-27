using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    [HttpGet("Cards")]
    public IActionResult GetCustomerCards(string documentNumber)
    {
        var cardService = new CardService();
        var customerCards = cardService.GetCustomerCards(documentNumber);

        if (!customerCards.Any())
        {
            return NoContent();
        }

        return Ok(customerCards);
    }

    // TODO: Criar as rotas Post, Put e Delete para Cartões
}