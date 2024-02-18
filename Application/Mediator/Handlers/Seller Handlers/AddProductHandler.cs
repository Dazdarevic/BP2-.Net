using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Seller_Commands;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Seller_Handlers
{
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;


        public AddProductHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            var pom = mapper.Map<Product>(request);

            uow.SellerRepository.AddProductAsync(pom);
            await uow.SaveAsync();
            var newAdmin = pom;
            return newAdmin;
        }
    }
}
