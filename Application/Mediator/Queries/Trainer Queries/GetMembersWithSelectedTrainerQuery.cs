using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Trainer_Queries
{
    public class GetMembersWithSelectedTrainerQuery : IRequest<IEnumerable<MemberByTrainerDto>>
    {
        public int TrainerId { get; }

        public GetMembersWithSelectedTrainerQuery(int trainerId)
        {
            TrainerId = trainerId;
        }
    }

}
