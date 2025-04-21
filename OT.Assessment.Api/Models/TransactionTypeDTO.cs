namespace OT.Assessment.Api.Models;

public class TransactionTypeDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}