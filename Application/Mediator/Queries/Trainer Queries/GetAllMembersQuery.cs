using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Trainer
{
    public class GetAllMembersQuery : IRequest<IEnumerable<Member>>
    {
    }
}
