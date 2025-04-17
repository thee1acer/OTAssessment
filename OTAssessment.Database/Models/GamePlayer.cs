namespace OT.Assessment.Database.Models;

public class GamePlayer : User
{
    public required int Age { get; set; }
    public required string Phone { get; set; }
}