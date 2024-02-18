using AutoMapper;
using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Trainer_Queries;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Handlers.Trainer_Handlers
{
    public class GetCommentByMemberHandler : IRequestHandler<GetCommentByMemberQuery, CommentDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetCommentByMemberHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<CommentDto> Handle(GetCommentByMemberQuery request, CancellationToken cancellationToken)
        {
            return await uow.TrainerRepository.GetCommentByMemberIdAsync(request.MemberId);
        }
    }
}
