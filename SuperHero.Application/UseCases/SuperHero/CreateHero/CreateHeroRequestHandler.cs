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

namespace SuperHero.Application.UseCases.SuperHero.CreateHero
{
    public class CreateHeroRequestHandler : IRequestHandler<CreateHeroRequest, Result<CreateHeroResponse>>
    {
        private readonly ISuperHeroDbContext _context;
        public CreateHeroRequestHandler(ISuperHeroDbContext context)
        {
            _context= context;
        }

        public async Task<Result<CreateHeroResponse>> Handle(CreateHeroRequest request, CancellationToken cancellationToken)
        {
            var heroValidator = await _context.SuperHeros.AsNoTracking().SingleOrDefaultAsync(x => x.Name.Equals(request.Name),cancellationToken);
            if (heroValidator != null)
            {
                return "That hero already exist.";
            }
            
            Superhero newHero = new Superhero(request.Name,
                request.Description,
                request.Publisher,
                request.Age,
                request.Powers,
                request.Association,
                request.ImgUrl);

            await _context.SuperHeros.AddAsync(newHero);

            await _context.SaveChangesAsync();

            return new CreateHeroResponse(newHero.Name,
                newHero.Description,
                newHero.Publisher,
                newHero.Age,
                newHero.Powers,
                newHero.Association,
                newHero.ImgUrl);
        }
    }
}
