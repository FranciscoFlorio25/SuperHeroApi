using MediatR;
using SuperHero.Application.Dto.Result;
using SuperHero.Application.UseCases.SuperHero.UpdateHeros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.UpdateHero
{
    public record UpdateHeroRequest(Guid id, string Name, string Description, string Publisher, int Age,
        string? Powers, string? Association, string? ImgUrl) : IRequest<Result<UpdateHeroResponse>>;

}
