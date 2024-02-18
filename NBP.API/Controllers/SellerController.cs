using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NBP.Application.Mediator.Commands.Seller_Commands;
using NBP.Application.Mediator.Queries.Seller_Queries;
using NBP.Domain.Entities;

namespace NPB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SellerController : ControllerBase
    {
        private readonly IMediator mediator;

        public SellerController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("add-product")]
        //[Authorize]
        public async Task<IActionResult> AddProduct(AddProductCommand product)
        {
            var addedProduct = await mediator.Send(product);
            return Ok(addedProduct);
        }

        //ovo mogu videti i clanovi
        [HttpGet("list-products")]
        [Authorize]
        public async Task<IActionResult> ListProducts()
        {
            var command = new ListProductsQuery();
            var products = await mediator.Send(command);
            return Ok(products);
        }
    }
}
