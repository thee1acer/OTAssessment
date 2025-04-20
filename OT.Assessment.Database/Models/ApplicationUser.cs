namespace OT.Assessment.Database.Models;

public class ApplicationUser: User
{
    public required Guid AccessLevelId { get; set; }
    public required AccessLevel AccesLevel { get; set; }
}