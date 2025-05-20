public class Transaction
{
    public int TransactionId { get; set; }

    public DateTime TransactionDateTime { get; set; }

    public string Description { get; set; }

    public int CardID { get; set; }

    public double Value { get; set; }
}