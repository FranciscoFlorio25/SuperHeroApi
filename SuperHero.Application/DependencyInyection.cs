using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SuperHero.Application.Dto.Result;

namespace SuperHero.Application
{
    public static class DependencyInyection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Result));

            return services;
        }
    }
}