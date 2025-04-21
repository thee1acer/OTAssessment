namespace OT.Assessment.Api.Models;

public class AccessLevelDTO
{
    public Guid Id { get; set; }
    public required string Type { get; set; }
    public required string Description { get; set; }
}