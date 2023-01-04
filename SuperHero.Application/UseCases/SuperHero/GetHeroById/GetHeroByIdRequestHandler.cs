using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Application.Dto.Result;
using SuperHero.Application.UseCases.SuperHero.GetHeros;
using SuperHero.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.FindHeroByName
{
    public class GetHeroByIdRequestHandler : IRequestHandler<GetHeroByIdRequest, Result<GetHeroByIdResponse>>
    {
        private readonly ISuperHeroDbContext _context;
        public GetHeroByIdRequestHandler(ISuperHeroDbContext context)
        {
            _context= context;
        }

        public async Task<Result<GetHeroByIdResponse>> Handle(GetHeroByIdRequest request, CancellationToken cancellationToken)
        {
            var hero = await _context.SuperHeros.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == request.Id);


            if(hero == null)
            {
                return "No hero found";
            }

            return new GetHeroByIdResponse(hero.Id,
             hero.Name,
             hero.Description,
             hero.Publisher,
             hero.Age,
             hero.Powers,
             hero.Association,
             hero.ImgUrl
             );
        }
    }
}
