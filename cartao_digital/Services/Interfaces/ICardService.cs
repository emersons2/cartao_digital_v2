public interface ICardService
{
    List<Card> GetCustomerCards(string documentNumber);

    Card CreateCustomerCard(string documentNumber);

    bool CheckCardIsValid(int cardId);

    Card GetCardForTransaction(PostTransactionRequest request);
}