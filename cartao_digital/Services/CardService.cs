public class CardService
{
    private readonly CardRepository _cardRepository = new CardRepository();

    public List<Card> GetCustomerCards(string documentNumber)
    {
        var customerService = new CustomerService();
        var customer = customerService.GetCustomers(documentNumber, null).FirstOrDefault();

        if (customer == null)
        {
            return [];
        }

        var cards = _cardRepository.GetCards().Where(x => x.CustomerId == customer.CustomerId);

        return cards.ToList();
    }

    public Card CreateCustomerCard(string documentNumber)
    {
        var customerService = new CustomerService();
        var customer = customerService.GetCustomers(documentNumber, null).FirstOrDefault();

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