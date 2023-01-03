using MediatR;
using SuperHero.Application.Dto.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.CreateHero
{
    public record CreateHeroRequest(string Name, string Description, string Publisher, int Age,
        string? Powers, string? Association, string? ImgUrl) : IRequest<Result<CreateHeroResponse>>;

}
