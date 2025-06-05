public interface ITransactionRepository
{
    List<Transaction> GetCardTransactions(int card);

    Transaction Add(Transaction transaction);

    Transaction Update(Transaction transaction);

    void Delete(int transactionId);
}