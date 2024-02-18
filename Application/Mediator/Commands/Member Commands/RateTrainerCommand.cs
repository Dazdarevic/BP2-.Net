using MediatR;

namespace NBP.Application.Mediator.Commands.Member_Commands
{
    public class RateTrainerCommand : IRequest<bool>
    {
        public int MemberId { get; set; }
        public int TrainerId { get; set; }
        public int RatingValue { get; set; }
    }
}
