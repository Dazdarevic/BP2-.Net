using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class CheckRatingQuery : IRequest<bool>
    {
        public int MemberId { get; }
        public int TrainerId { get; }

        public CheckRatingQuery(int memberId, int trainerId)
        {
            MemberId = memberId;
            TrainerId = trainerId;
        }
    }
}
