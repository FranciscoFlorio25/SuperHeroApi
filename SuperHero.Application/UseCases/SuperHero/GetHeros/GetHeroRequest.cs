﻿using MediatR;
using SuperHero.Application.Dto.Result;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SuperHero.Application.UseCases.SuperHero.GetHeros
{
    public record GetHeroRequest() : IRequest<Result<GetHeroResponse>>;

}
