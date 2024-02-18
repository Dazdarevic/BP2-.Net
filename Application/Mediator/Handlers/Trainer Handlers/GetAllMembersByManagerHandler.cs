using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{
    public class GetAllMembersByManagerHandler : IRequestHandler<GetAllMembersByManager, IEnumerable<MemberInfoDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllMembersByManagerHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MemberInfoDto>> Handle(GetAllMembersByManager request, CancellationToken cancellationToken)
        {
            var members = await uow.TrainerRepository.GetAllMembersByManager();
            return mapper.Map<IEnumerable<MemberInfoDto>>(members);
        }
    }
}
