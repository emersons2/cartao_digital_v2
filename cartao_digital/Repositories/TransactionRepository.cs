public static class TransactionRepository
{
    private static List<Transaction> Transactions { get; } = [];

    private static int transactionId = 1;

    public static List<Transaction> GetTransactions()
    {
        return Transactions;
    }

    public static void Add(Transaction transaction)
    {
        transaction.TransactionId = transactionId;
        Transactions.Add(transaction);
        transactionId++;
    }

    public static void Update(Transaction transaction)
    {
        var existingTransaction = Transactions.FirstOrDefault(x => x.TransactionId == transaction.TransactionId);

        if (existingTransaction is null)
        {
            throw new Exception("Not found.");
        }

        existingTransaction.Description = transaction.Description;
        existingTransaction.TransactionDateTime = transaction.TransactionDateTime;
        existingTransaction.Value = transaction.Value;
        existingTransaction.CardId = transaction.CardId;
    }

    public static void Delete(int transactionId)
    {
        var existingTransaction = Transactions.FirstOrDefault(x => x.TransactionId == transactionId);

        if (existingTransaction is null)
        {
            throw new Exception("Not found.");
        }

        Transactions.Remove(existingTransaction);
    }
}
