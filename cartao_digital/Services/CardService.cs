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

    public Card GetCardForTransaction(PostTransactionRequest request)
    {
        var card = _cardRepository.GetCards().FirstOrDefault(x => x.CardNumber == request.CardNumber);

        if (card == null)
        {
            throw new Exception("Cartão não encontrado");
        }

        if (card.DueDate.Date < DateTime.Now.Date)
        {
            throw new Exception("Cartão vencido");
        }

        if (card.VerificationCode != request.VerificationCode)
        {
            throw new Exception("Código de verificação incorreto");
        }

        if (card.DueDate.Date != request.DueDate.Date)
        {
            throw new Exception("Data de vencimento incorreta");
        }

        return card;
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

    public Card CreateNewCard()
    {
        var card = new Card();
        card.CardNumber = CreditCardGenerator.GenerateCardNumber("4539", 16);
        card.DueDate = DateTime.Now.AddYears(3);
        card.VerificationCode = CreditCardGenerator.GenerateCVV();

        return card;
    }

    // TODO: Precisamos de métodos para Criar, Atualizar e Deletar cartões
}
