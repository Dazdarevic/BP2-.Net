using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Commands.Receptionist_Commands
{
    public class CreatePaymentCommand : IRequest<bool>
    {
        public int? paymentId { get; set; }
        public DateTime? Date { get; set; }
        public string? memberName { get; set; }

        public int? ID { get; set; }
        public CreatePaymentCommand()
        {
            this.Date = DateTime.Now;
        }
    }
}
