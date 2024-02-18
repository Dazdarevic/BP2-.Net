using MediatR;
using NBP.Domain.Entities;

namespace NBP.Application.Mediator.Commands.Sponsor_Commands
{
    public class AddAdCommand : IRequest<Advertisement>
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Url { get; set; }
        public bool IsMain { get; set; }
        public string? PublicId { get; set; }
        public int SponsorId { get; set; }
    }

}
