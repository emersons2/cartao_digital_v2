using Microsoft.AspNetCore.Mvc;

public interface ITransactionService
{
    List<Transaction> GetTransactions(int cardId, DateTime startDate, DateTime endDate);

    Task<Transaction> PostTransaction(PostTransactionRequest request);

    FileContentResult GetTransactionsFile(int cardId, DateTime startDate, DateTime endDate);
}