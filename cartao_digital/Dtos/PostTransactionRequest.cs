public class PostTransactionRequest
{
    public string CardNumber { get; set; }

    public string VerificationCode { get; set; }

    public DateTime DueDate { get; set; }

    public string Description { get; set; }

    public double Value { get; set; }
}