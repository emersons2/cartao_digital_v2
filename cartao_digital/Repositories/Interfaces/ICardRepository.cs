public interface ICardRepository
{
    List<Card> GetCards();

    Card Add(Card card);

    Card Update(Card card);

    void Delete(int cardId);
}