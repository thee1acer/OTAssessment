namespace OT.Assessment.Models;

public class TransactionDTO : AuditDTO
{
    public Guid Id { get; set; }
    public double Amount { get; set; }
    public int NumberOfBets { get; set; }
    public DateTime CreatedDateTime { get; set; }

    public Guid TransactionTypeId { get; set; }
    public required TransactionTypeDTO Type { get; set; }
    
    public Guid UserId { get; set; }
    public required UserDTO User { get; set; }
}