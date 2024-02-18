using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Queries.Sponsor_Queries
{
    public class ListAdsQuery : IRequest<IEnumerable<Advertisement>>
    {
    }
}
