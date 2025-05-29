using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class CardController : ControllerBase
{
    private readonly ICardService _cardService;

    public CardController(ICardService cardService)
    {
        _cardService = cardService;
    }

    [HttpGet("Cards")]
    public IActionResult GetCustomerCards(string documentNumber)
    {
        var customerCards = _cardService.GetCustomerCards(documentNumber);

        if (!customerCards.Any())
        {
            return NoContent();
        }

        return Ok(customerCards);
    }

    [HttpPost("Card")]
    public IActionResult CreateCustomerCard(string documentNumber)
    {
        var customerCard = _cardService.CreateCustomerCard(documentNumber);
        return Accepted(customerCard);
    }
    // TODO: Criar as rotas Post, Put e Delete para Cartões
}