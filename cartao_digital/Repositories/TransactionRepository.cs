
public class TransactionRepository : ITransactionRepository
{
    private readonly JsonDatabase<Transaction> _jsonDb = new JsonDatabase<Transaction>();

    public List<Transaction> GetCardTransactions(int cardId)
    {
        return _jsonDb.GetData().Where(x => x.CardId == cardId).ToList();
    }

    public Transaction Add(Transaction transaction)
    {
        var transactions = _jsonDb.GetData();
        transaction.TransactionId = transactions.Count > 0 ? transactions.Max(t => t.TransactionId) + 1 : 1;
        transactions.Add(transaction);
        _jsonDb.SaveChanges(transactions);

        return transaction;
    }

    public Transaction Update(Transaction transaction)
    {
        var transactions = _jsonDb.GetData();

        var index = transactions.FindIndex(t => t.TransactionId == transaction.TransactionId);
        if (index >= 0)
        {
            transactions[index] = transaction;
            _jsonDb.SaveChanges(transactions);
        }

        return transaction;
    }

    public void Delete(int transactionId)
    {
        var transactions = _jsonDb.GetData().Where(t => t.TransactionId != transactionId).ToList();
        _jsonDb.SaveChanges(transactions);
    }
}
