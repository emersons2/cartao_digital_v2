public class CardService : ICardService
{
    private readonly ICustomerService _customerService;
    private readonly ICardRepository _cardRepository;

    public CardService(ICustomerService customerService, ICardRepository cardRepository)
    {
        _customerService = customerService;
        _cardRepository = cardRepository;
    }

    public List<Card> GetCustomerCards(string documentNumber)
    {
        var customer = _customerService.GetCustomers(documentNumber, null).FirstOrDefault();

        if (customer == null)
        {
            return [];
        }

        var cards = _cardRepository.GetCards().Where(x => x.CustomerId == customer.CustomerId);

        return cards.ToList();
    }

    public bool CheckCardIsValid(int cardId)
    {
        var card = _cardRepository.GetCards().FirstOrDefault(x => x.CardId == cardId);

        if (card == null)
        {
            return false;
        }

        if (card.DueDate < DateTime.Now)
        {
            return false;
        }

        return true;
    }

    public Card CreateCustomerCard(string documentNumber)
    {
        var customer = _customerService.GetCustomers(documentNumber, null).FirstOrDefault();

        if (customer == null)
        {
            throw new Exception("Cliente não encontrado");
        }

        var newCard = CreateNewCard();
        newCard.CustomerId = customer.CustomerId;

        _cardRepository.Add(newCard);

        return newCard;
    }

    private Card CreateNewCard()
    {
        var card = new Card();
        card.CardNumber = CreditCardGenerator.GenerateCardNumber("4539", 16);
        card.DueDate = DateTime.Now.AddYears(3);
        card.VerificationCode = CreditCardGenerator.GenerateCVV();

        return card;
    }

    // TODO: Precisamos de métodos para Criar, Atualizar e Deletar cartões
}