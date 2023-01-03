using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Application.Data;
using SuperHero.Infraestructure.Data;

namespace SuperHero.Infraestructure
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddDbContext<ISuperHeroDbContext, SuperHeroDbContext>
                (o => o.UseSqlServer(configuration.GetConnectionString(name: "Default")));

            return service;
        }
    }
}