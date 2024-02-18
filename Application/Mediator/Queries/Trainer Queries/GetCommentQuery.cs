using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Trainer_Queries
{
    public class GetCommentQuery : IRequest<CommentDto>
    {
        public int TrainerId { get; }
        public int MemberId { get; }

        public GetCommentQuery(int trainerId, int memberId)
        {
            TrainerId = trainerId;
            MemberId = memberId;
        }
    }
}
