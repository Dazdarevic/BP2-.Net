using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Admin;

namespace NBP.Application.Mediator.Handlers.Admin
{
    public class DeleteAdminHandler : IRequestHandler<DeleteAdminCommand>
    {
        private readonly IUnitOfWork uow;

        public DeleteAdminHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(DeleteAdminCommand request, CancellationToken cancellationToken)
        {
            uow.AdministratorRepository.DeleteAdmin(request.AdminId);
            await uow.SaveAsync();
        }
    }
}
