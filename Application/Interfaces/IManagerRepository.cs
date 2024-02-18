using NBP.Application.DTOs;

namespace NBP.Application.Interfaces
{
    public interface IManagerRepository
    {
        Task<IEnumerable<TrainerWithSalaryDto>> GetAllTrainersWithSalariesAsync();
        Task<int> GetTrainerIdOccurrenceAsync(int trainerId);

        Task AddOrUpdateTrainerSalaryAsync(int trainerId, string salaryAmount);
        Task AddMembershipAmount(int memberId, string membershipAmount);

    }
}
