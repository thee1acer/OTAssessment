namespace OT.Assessment.Models;

public class AccessLevelDTO
{
    public Guid Id { get; set; }
    public required string AccesType { get; set; }
    public required string AccessDescription { get; set; }
}