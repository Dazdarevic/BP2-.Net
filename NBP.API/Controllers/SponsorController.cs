using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Sponsor_Commands;
using NBP.Application.Mediator.Queries.Sponsor_Queries;
using NBP.Domain.Entities;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SponsorController : ControllerBase
    {
        private readonly IMediator mediator;

        public SponsorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-ad")]
        //[Authorize]
        public async Task<IActionResult> AddAd(AddAdCommand ad)
        {
            var addedAd = await mediator.Send(ad);
            return Ok(addedAd);
        }

        //ovo mogu videti i clanovi
        [HttpGet("list-ads")]
        [Authorize]
        public async Task<IActionResult> ListAds()
        {
            var command = new ListAdsQuery();
            var ads = await mediator.Send(command);
            return Ok(ads);
        }
    }
}
