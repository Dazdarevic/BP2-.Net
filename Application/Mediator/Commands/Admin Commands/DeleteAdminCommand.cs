using MediatR;

namespace NBP.Application.Mediator.Commands.Admin
{
    public class DeleteAdminCommand : IRequest
    {
        public int AdminId { get; set; }

        public DeleteAdminCommand(int adminId)
        {
            AdminId = adminId;
        }
    }
}
