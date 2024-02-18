using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Domain.Identity;

namespace NBP.Application.Interfaces
{
    public interface IReceptionistRepository
    {
        Task<bool> CreateRegistrationRequestAsync(RegistrationRequest request);
        Task<IEnumerable<RegistrationRequest>> GetAllRequestsAsync();
        Task<bool> ApproveRegistrationRequestAsync(int requestId);
        Task<bool> DeleteRequestAsync(int requestId);
        Task<bool> EmailExistsAsync(string email);
        Task<bool> CreatePaymentAsync(Payment payment);
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<IEnumerable<PaymentDto>> GetAllPaymentsAsync();
    }
}
