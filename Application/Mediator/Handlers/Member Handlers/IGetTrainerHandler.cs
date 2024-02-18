using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public interface IGetTrainerHandler
    {
        Task<TrainerUser> Handle(GetTrainerQuery request, CancellationToken cancellationToken);
    }
}