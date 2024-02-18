using MediatR;
using NBP.Application.DTOs;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Queries.User;

namespace NBP.Application.Mediator.Handlers.User_Handlers
{
    public class GetUserByIdAndRoleQueryHandler : IRequestHandler<GetUserByIdAndRoleQuery, UserInfoDto>
    {
        private readonly IUnitOfWork uow;

        public GetUserByIdAndRoleQueryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }


        public Task<UserInfoDto> Handle(GetUserByIdAndRoleQuery request, CancellationToken cancellationToken)
        {
            return Task.FromResult(uow.UserInfoRepository.GetUserByIdAndRole(request.UserId, request.Role));
        }
    }

}
