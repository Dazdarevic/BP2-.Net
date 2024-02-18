using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetAllTrainersByMemberHandler : IRequestHandler<GetAllTrainersByMemberQuery, IEnumerable<TrainerDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllTrainersByMemberHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<TrainerDto>> Handle(GetAllTrainersByMemberQuery request, CancellationToken cancellationToken)
        {
            var trainers = await uow.MemberRepository.GetAllTrainersAsync();
            var trainersDto = mapper.Map<IEnumerable<TrainerDto>>(trainers);
            return trainersDto;
        }
    }
}
