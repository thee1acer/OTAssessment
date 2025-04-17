namespace OT.Assessment.Database.Models;

public class ApplicationUser: User
{
    public required AccessLevel AccesLevel { get; set; }
}