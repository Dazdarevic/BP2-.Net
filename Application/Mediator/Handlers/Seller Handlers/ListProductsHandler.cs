using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Seller_Queries;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Seller_Handlers
{
    public class ListProductsHandler : IRequestHandler<ListProductsQuery, IEnumerable<Product>>
    {
        private readonly IUnitOfWork uow;

        public ListProductsHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task<IEnumerable<Product>> Handle(ListProductsQuery request, CancellationToken cancellationToken)
        {
            return await uow.SellerRepository.GetAllProductsAsync();
        }
    }

}
