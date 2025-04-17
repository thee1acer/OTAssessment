namespace OT.Assessment.Database.Models;

public class Wager
{
    public Guid Id { get; set; }
    public required string SessionData { get; set; }
    public required long Duration { get; set; }
    public required Theme Theme { get; set; }
    public required Provider Provider { get; set; }
    public required Game Game { get; set; }
    public required Transaction Transaction { get; set; }
    public required Country Country { get; set; }
}