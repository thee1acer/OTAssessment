namespace OT.Assessment.Database.Models;

public class Transaction : Audit
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public int NumberOfBets { get; set; }
    public DateTime CreatedDateTime { get; set; }

    public Guid TransactionTypeId { get; set; }
    public required TransactionType Type { get; set; }
    
    public Guid UserId { get; set; }
    public required User User { get; set; }
}