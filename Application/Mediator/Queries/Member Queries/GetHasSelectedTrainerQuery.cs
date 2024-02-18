using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetHasSelectedTrainerQuery : IRequest<bool>
    {
        public int MemberId { get; set; } 
    }
}
