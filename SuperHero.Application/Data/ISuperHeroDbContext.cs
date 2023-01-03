using Microsoft.EntityFrameworkCore;
using SuperHero.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Application.Data
{
    public interface ISuperHeroDbContext
    {
        DbSet<Superhero> SuperHeros { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
