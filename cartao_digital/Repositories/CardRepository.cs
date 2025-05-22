public static class CardRepository
{
    private static List<Card> Cards { get; } = [];

    private static int cardId = 1;

    public static List<Card> GetCards()
    {
        return Cards;
    }

    public static void Add(Card card)
    {
        card.CardId = cardId;
        Cards.Add(card);
        cardId++;
    }

    public static void Update(Card card)
    {
        var existingCard = Cards.FirstOrDefault(x => x.CardId == card.CardId);

        if (existingCard is null)
        {
            throw new Exception("Not found.");
        }

        existingCard.CardNumber = card.CardNumber;
        existingCard.DueDate = card.DueDate;
        existingCard.VerificationCode = card.VerificationCode;
    }

    public static void Delete(int cardId)
    {
        var existingCard = Cards.FirstOrDefault(x => x.CardId == cardId);

        if (existingCard is null)
        {
            throw new Exception("Not found.");
        }

        Cards.Remove(existingCard);
    }
}
