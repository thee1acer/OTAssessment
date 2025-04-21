namespace OT.Assessment.Database.Models;

public class AccessLevel
{
    public Guid Id { get; set; }
    public required string Type { get; set; }
    public required string Description { get; set; }
}