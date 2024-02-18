using MediatR;

namespace NBP.Application.Mediator.Queries.Member_Queries
{
    public class GetAverageRating : IRequest<double>
    {
        public int TrainerId { get; set; }

    }
}
