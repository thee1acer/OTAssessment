namespace OT.Assessment.Api.Models;

public class ProviderDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public virtual ICollection<GameDTO>? Games { get; set; }
}