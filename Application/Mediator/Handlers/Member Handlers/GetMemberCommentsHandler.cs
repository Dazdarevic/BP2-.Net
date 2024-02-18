using AutoMapper;
using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.Member_Queries;

namespace NBP.Application.Mediator.Handlers.Member_Handlers
{
    public class GetMemberCommentsHandler : IRequestHandler<GetMemberCommentsQuery, IEnumerable<MemberComment>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetMemberCommentsHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MemberComment>> Handle(GetMemberCommentsQuery request, CancellationToken cancellationToken)
        {
            var comments = await uow.MemberRepository.GetMemberCommentsAsync(request.MemberId);
            return mapper.Map<IEnumerable<MemberComment>>(comments);
        }
    }
}
