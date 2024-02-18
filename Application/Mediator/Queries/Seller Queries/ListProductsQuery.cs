using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Queries.Seller_Queries
{
    public class ListProductsQuery : IRequest<IEnumerable<Product>>
    {
    }
}
