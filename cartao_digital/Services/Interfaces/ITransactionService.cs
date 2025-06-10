using Microsoft.AspNetCore.Mvc;

public interface ITransactionService
{
    List<Transaction> GetTransactions(int cardId, DateTime startDate, DateTime endDate);

    Transaction PostTransaction(PostTransactionRequest transaction);

    FileContentResult GetTransactionsFile(int cardId, DateTime startDate, DateTime endDate);
}