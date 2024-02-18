using MediatR;
using NBP.Application.DTOs;

namespace NBP.Application.Mediator.Queries.User
{
    public class GetUserByIdAndRoleQuery : IRequest<UserInfoDto>
    {
        public int UserId { get; set; }
        public string Role { get; set; }

        public GetUserByIdAndRoleQuery(int userId, string role)
        {
            UserId = userId;
            Role = role;
        }
    }


}
