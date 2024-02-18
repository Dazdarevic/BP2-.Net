using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class SortTrainersQueryHandler : IRequestHandler<SortTrainersQuery, IEnumerable<TrainerUser>>
    {
        private readonly IUnitOfWork uow;
        public SortTrainersQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        //public async Task<IEnumerable<TrainerUser>> Handle(SortTrainersQuery request, CancellationToken cancellationToken)
        //{
        //    if (request.SortByField != null && (request.SortByField == "firstName" || request.SortByField == "lastName"))
        //    {
        //        return await uow.MemberRepository.SortTrainersAsync(request.SortByField);
        //    }
        //    return null;
        //}

        public async Task<IEnumerable<TrainerUser>> Handle(SortTrainersQuery request, CancellationToken cancellationToken)
        {
            if (request.SortByField != null && (request.SortByField == "firstName" || request.SortByField == "lastName"))
            {
                return await uow.MemberRepository.SortTrainersAsync(request.SortByField, request.Page, request.PageSize);
            }
            return null;
        }

    }

}
