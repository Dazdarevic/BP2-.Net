using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Sponsor_Queries;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Handlers.Sponsor_Handlers
{
    public class ListAdsHandler : IRequestHandler<ListAdsQuery, IEnumerable<Advertisement>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public ListAdsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Advertisement>> Handle(ListAdsQuery request, CancellationToken cancellationToken)
        {
            var ads = await uow.SponsorRepository.GetAllAdsAsync();
            return ads;
        }
    }

}
