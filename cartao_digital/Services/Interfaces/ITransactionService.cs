public interface ITransactionService
{
    List<Transaction> GetTransactions(int cardId, DateTime startDate, DateTime endDate);
    
    Transaction PostTransaction(Transaction transaction);
}