using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Commands.Seller_Commands
{
    public class AddProductCommand : IRequest<Product>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public string? Price { get; set; }
        // za sliku
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }

        public int SellerId { get; set; }
    }

}
