namespace OT.Assessment.Database.Models;

public class AccessLevel
{
    public Guid Id { get; set; }
    public required string AccesType { get; set; }
    public required string AccessDescription { get; set; }
}