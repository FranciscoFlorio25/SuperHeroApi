using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.GetHeroByName
{
    public record HeroByName(Guid Id, string Name, string Description, string Publisher, int Age,
    string? Powers, string? Association, string? ImgUrl);
    public record GetHeroByNameResponse(IEnumerable<HeroByName> Hero);
}