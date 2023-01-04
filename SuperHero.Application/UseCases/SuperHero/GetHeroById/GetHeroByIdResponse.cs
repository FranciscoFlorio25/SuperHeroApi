using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.GetHeroById
{
    public record GetHeroByIdResponse(Guid Id, string Name, string Description, string Publisher, int Age,
    string? Powers, string? Association, string? ImgUrl);
}