using MediatR;

namespace NBP.Application.Mediator.Commands.Trainer_Commands
{
    public class UpdateCommentTextCommand : IRequest<bool>
    {
        public int CommentId { get; }
        public string CommentText { get; }

        public UpdateCommentTextCommand(int commentId, string commentText)
        {
            CommentId = commentId;
            CommentText = commentText;
        }
    }

}
