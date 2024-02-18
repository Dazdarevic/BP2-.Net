using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.Trainer_Queries
{

    public class GetCommentByMemberQuery : IRequest<CommentDto>
    {
        public int MemberId { get; }

        public GetCommentByMemberQuery(int memberId)
        {
            MemberId = memberId;
        }
    }
}
