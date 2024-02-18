using MediatR;

namespace NBP.Application.Mediator.Queries.Manager_Queries
{
    public class GetTrainerOccurrenceQuery : IRequest<int>
    {
        public int TrainerId { get; }

        public GetTrainerOccurrenceQuery(int trainerId)
        {
            TrainerId = trainerId;
        }
    }
}
