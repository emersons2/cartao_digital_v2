public class CardRepository
{
    private readonly JsonDatabase<Card> _jsonDb = new JsonDatabase<Card>();
    
    public List<Card> GetCards()
    {
        return _jsonDb.GetData();
    }

    public Card Add(Card card)
    {
        var cards = _jsonDb.GetData();
        card.CardId = cards.Count > 0
            ? cards.Max(x => x.CardId) + 1
            : 1;

        // if (cards.Count > 0)
        // {
        //     card.CardId = cards.Max(x => x.CardId) + 1;
        // }
        // else
        // {
        //     card.CardId = 1;
        // }

        cards.Add(card);
        _jsonDb.SaveChanges(cards);

        return card;
    }

    public Card Update(Card card)
    {
        var cards = _jsonDb.GetData();

        // Verifique se todos os itens da minha lista possuem
        // data de vencimento futura.

        var index = cards.FindIndex(c => c.CardId == card.CardId);
        if (index >= 0)
        {
            cards[index] = card;
            _jsonDb.SaveChanges(cards);
        }

        return card;
    }

    public void Delete(int cardId)
    {
        var cards = _jsonDb.GetData().Where(c => c.CardId != cardId).ToList();
        _jsonDb.SaveChanges(cards);
    }
}
