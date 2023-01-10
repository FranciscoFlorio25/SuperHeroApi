using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Application.Dto.Result;
using SuperHero.Application.UseCases.SuperHero.GetHeroById;
using SuperHero.Application.UseCases.SuperHero.GetHeros;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.GetHeroByName
{
    public class GetHeroByNameRequestHandler : IRequestHandler<GetHeroByNameRequest, Result<GetHeroByNameResponse>>
    {
        private readonly ISuperHeroDbContext _context;
        public GetHeroByNameRequestHandler(ISuperHeroDbContext context)
        {
            _context= context;
        }

        public async Task<Result<GetHeroByNameResponse>> Handle(GetHeroByNameRequest request, CancellationToken cancellationToken)
        {
            var hero = await _context.SuperHeros.AsNoTracking()
                .Where(x => x.Name.Equals(request.Name)).ToListAsync();


            if (hero == null)
            {
                return "No hero found";
            }
            var foundHeroes = hero.Select(x => new HeroByName(
                x.Id, x.Name, x.Description, x.Publisher, x.Age, x.Powers, x.Association, x.ImgUrl));


            return new GetHeroByNameResponse(foundHeroes);
        }
    }
}
