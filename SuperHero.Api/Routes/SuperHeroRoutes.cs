using MediatR;
using Microsoft.AspNetCore.Mvc;
using SuperHero.Api.Extension;
using SuperHero.Application.UseCases.SuperHero.CreateHero;
using SuperHero.Application.UseCases.SuperHero.DeleteHero;
using SuperHero.Application.UseCases.SuperHero.GetHeroByName;
using SuperHero.Application.UseCases.SuperHero.GetHeroById;
using SuperHero.Application.UseCases.SuperHero.GetHeros;
using SuperHero.Application.UseCases.SuperHero.UpdateHero;

namespace SuperHero.Api.Routes
{
    public static class SuperHeroRoutes
    {
        const string PATH = "/SuperHero";

        public static IEndpointRouteBuilder MapSuperHeroes(this IEndpointRouteBuilder builder)
        {
            var group = builder.MapGroup(PATH);

            group.MapGet("", async (IMediator mediator) => 
             await mediator.Send(new GetHeroRequest()).ToHttpResult());

            group.MapGet("{id}", async (Guid id,IMediator mediator) =>
            await mediator.Send(new GetHeroByIdRequest(id)).ToHttpResult());

            group.MapGet("{name}", async (string name, IMediator mediator) =>
            await mediator.Send(new GetHeroByNameRequest(name)).ToHttpResult());

            group.MapPost("", async (CreateHeroRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());

            group.MapPut("", async (UpdateHeroRequest request, IMediator mediator) =>
            await mediator.Send(request).ToHttpResult());

            group.MapDelete("{id}", async (Guid id, IMediator mediator) =>
            await mediator.Send(new DeleteHeroRequest(id)).ToHttpResult());

            return builder;
        }
    }
}
