using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Trainer;
using NBP.Domain.Identity;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{
    public class GetAllMembersHandler : IRequestHandler<GetAllMembersQuery, IEnumerable<Member>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllMembersHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Member>> Handle(GetAllMembersQuery request, CancellationToken cancellationToken)
        {
            var members = await uow.TrainerRepository.GetAllMembersAsync();
            return members;
        }
    }

}
