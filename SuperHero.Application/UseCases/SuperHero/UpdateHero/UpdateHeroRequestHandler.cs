using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Application.Dto.Result;
using SuperHero.Application.UseCases.SuperHero.UpdateHeros;
using SuperHero.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.UpdateHero
{
    public class UpdateHeroRequestHandler : IRequestHandler<UpdateHeroRequest,Result<UpdateHeroResponse>>
    {
        private readonly ISuperHeroDbContext _context;
        public UpdateHeroRequestHandler(ISuperHeroDbContext context)
        {
            _context= context;
        }

        public async Task<Result<UpdateHeroResponse>> Handle(UpdateHeroRequest request, CancellationToken cancellationToken)
        {
            var toUpdate = await _context.SuperHeros.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.id,cancellationToken);

            if (toUpdate == null)
            {
                return "No hero found with that id!";
            }

            toUpdate = request.Adapt(toUpdate);

            if(toUpdate != null)
            {
               _context.SuperHeros.Update(toUpdate);
               await _context.SaveChangesAsync(cancellationToken);

                return new UpdateHeroResponse(
                    toUpdate.Name,
                    toUpdate.Description,
                    toUpdate.Publisher,
                    toUpdate.Age,
                    toUpdate.Powers,
                    toUpdate.Association,
                    toUpdate.ImgUrl);
            }
            else
            {
                return "Hero could not be updated";
            }
           

        }
    }
}
