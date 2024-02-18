using MediatR;

namespace NBP.Application.Mediator.Commands.Manager_Commands
{
        public class AddTrainerSalaryCommand : IRequest
        {
            public int TrainerId { get; }
            public string SalaryAmount { get; }

            public AddTrainerSalaryCommand(int trainerId, string salaryAmount)
            {
                TrainerId = trainerId;
                SalaryAmount = salaryAmount;
            }
        }
    }

