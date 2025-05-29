public interface ICardService
{
    List<Card> GetCustomerCards(string documentNumber);

    Card CreateCustomerCard(string documentNumber);
}