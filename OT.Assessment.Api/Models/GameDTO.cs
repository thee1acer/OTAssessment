namespace OT.Assessment.Api.Models;

public class GameDTO
{
    public Guid Id { get; set; }
    public required string Name { get; set; }
    
    public required string ThemeName { get; set; }
    public virtual required ThemeDTO Theme { get; set; }

    public Guid ProviderId { get; set; }
    public virtual required ProviderDTO Provider { get; set; }    
}