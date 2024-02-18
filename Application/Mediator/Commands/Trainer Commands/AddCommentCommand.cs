using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Commands.Trainer_Commands
{
    public class AddCommentCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int TrainerId { get; set; }
        public int MemberId { get; set; }
        public string? Text { get; set; }
        
    }

}
