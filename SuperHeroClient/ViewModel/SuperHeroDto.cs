namespace SuperHeroClient.ViewModel
{
    public record SuperHeroDto(
     Guid Id,
     string Name,
     string Description,
     string Publisher,
     int Age,
     string? Powers,
     string? Association,
     string? ImgUrl
     );
}
