using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Application.Dto.Result;
using SuperHero.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.GetHeros
{
    public class GetHeroRequestHandler : IRequestHandler<GetHeroRequest, Result<GetHeroResponse>>
    {
        private readonly ISuperHeroDbContext _context;
        public GetHeroRequestHandler(ISuperHeroDbContext context)
        {
            _context = context;
        }

        public async Task<Result<GetHeroResponse>> Handle(GetHeroRequest request, CancellationToken cancellationToken)
        {
            var heros = await _context.SuperHeros.AsNoTracking().ToListAsync(cancellationToken);

            if (heros == null || !heros.Any())
            {
                return "No heroes found, who could save us all!?";
            }

            var foundHeroes = heros.Select(x => new Heros(
                x.Id,x.Name,x.Description,x.Publisher,x.Age,x.Powers,x.Association,x.ImgUrl));

            return new GetHeroResponse(foundHeroes);
        }
    }
}
