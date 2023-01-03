using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Application.Dto.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.DeleteHero
{
    public class DeleteHeroRequestHandler : IRequestHandler<DeleteHeroRequest,Result>
    {
        private readonly ISuperHeroDbContext _context;
        public DeleteHeroRequestHandler(ISuperHeroDbContext context)
        {
            _context= context;
        }

        public async Task<Result> Handle(DeleteHeroRequest request, CancellationToken cancellationToken)
        {
            var hero = await _context.SuperHeros.AsNoTracking().SingleOrDefaultAsync(x => x.Id == request.id,cancellationToken);

            if (hero == null)
            {
                return "No hero found";
            }

            _context.SuperHeros.Remove(hero);
            await _context.SaveChangesAsync(cancellationToken);

            return "SuperHero deleted, has he/she become a villian!?";
        }
    }
}
