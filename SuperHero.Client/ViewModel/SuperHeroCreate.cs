namespace SuperHero.Client.ViewModel
{
    public record SuperHeroCreate(Guid Id,
     string Name,
     string Description,
     string Publisher,
     int Age,
     string? Powers,
     string? Association,
     string? ImgUrl);
}
