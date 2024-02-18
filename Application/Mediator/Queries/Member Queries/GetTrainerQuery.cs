using MediatR;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetTrainerQuery : IRequest<TrainerUser>
    {
        public int TrainerId { get; }

        public GetTrainerQuery(int trainerId)
        {
            TrainerId = trainerId;
        }
    }
}
