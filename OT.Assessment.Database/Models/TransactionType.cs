namespace OT.Assessment.Database.Models;
public class TransactionType
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
}