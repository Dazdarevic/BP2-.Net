using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetAllTrainersByMemberQuery : IRequest<IEnumerable<TrainerDto>>
    {
    }
}
