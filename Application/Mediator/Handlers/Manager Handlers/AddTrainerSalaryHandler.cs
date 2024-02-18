using MediatR;
using NBP.Application.Interfaces;
using NBP.Application.Mediator.Commands.Manager_Commands;

namespace NBP.Application.Mediator.Handlers.Trainers
{
    public class AddTrainerSalaryHandler : IRequestHandler<AddTrainerSalaryCommand>
    {
        private readonly IUnitOfWork uow;

        public AddTrainerSalaryHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        public async Task Handle(AddTrainerSalaryCommand request, CancellationToken cancellationToken)
        {
            await uow.ManagerRepository.AddOrUpdateTrainerSalaryAsync(request.TrainerId, request.SalaryAmount);
            await uow.SaveAsync();
        }
    }
}
