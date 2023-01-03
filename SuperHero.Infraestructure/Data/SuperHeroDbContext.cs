using Microsoft.EntityFrameworkCore;
using SuperHero.Application.Data;
using SuperHero.Domain.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperHero.Infraestructure.Data
{
    public class SuperHeroDbContext : DbContext, ISuperHeroDbContext
    {
        public SuperHeroDbContext(DbContextOptions options): base(options) { }

        public DbSet<Superhero> SuperHeros => Set<Superhero>();
    }
}
