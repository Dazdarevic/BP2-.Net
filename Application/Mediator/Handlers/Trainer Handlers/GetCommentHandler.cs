using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Trainer_Queries;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{
    public class GetCommentHandler : IRequestHandler<GetCommentQuery, CommentDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetCommentHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            return await uow.TrainerRepository.GetCommentByTrainerAndMemberIdAsync(request.TrainerId, request.MemberId);
        }
    }
}
