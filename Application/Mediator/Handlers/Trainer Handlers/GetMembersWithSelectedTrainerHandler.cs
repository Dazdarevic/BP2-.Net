using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Trainer_Queries;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{

    public class GetMembersWithSelectedTrainerHandler : IRequestHandler<GetMembersWithSelectedTrainerQuery, IEnumerable<MemberByTrainerDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper _mapper;
        public GetMembersWithSelectedTrainerHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<MemberByTrainerDto>> Handle(GetMembersWithSelectedTrainerQuery request, CancellationToken cancellationToken)
        {
            var membersWithSelectedTrainer = await uow.TrainerRepository.GetMembersWithSelectedTrainerAsync(request.TrainerId);

            var result = _mapper.Map<IEnumerable<MemberByTrainerDto>>(membersWithSelectedTrainer);

            return result;
        }
    }
}
