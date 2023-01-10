namespace SuperHero.Client.ViewModel
{
    public record SuperHeroUpdate(Guid Id,
     string Name,
     string Description,
     string Publisher,
     int Age,
     string? Powers,
     string? Association,
     string? ImgUrl);
}
