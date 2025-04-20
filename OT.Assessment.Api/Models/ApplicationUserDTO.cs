namespace OT.Assessment.Models;

public class ApplicationUserDTO: UserDTO
{
    public required Guid AccessLevelId { get; set; }
    public required AccessLevelDTO AccesLevel { get; set; }
}