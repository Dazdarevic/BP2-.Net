using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Domain.Identity;
using Microsoft.AspNetCore.Mvc;


namespace NBP.Application.Interfaces
{
    public interface IMemberRepository
    {
        //pregled liste trenera
        Task<IEnumerable<TrainerUser>> GetAllTrainersAsync();

        //pregled licnih podataka
        Task<Member> GetMember(int memberId);
        Task<TrainerUser> GetTrainer(int trainerId);
        Task<ActionResult<object>> GetPagTrainersAsync(int page = 1, int pageSize = 10);
        Task<ActionResult<object>> SortPagTrainersAsync(int page = 1, int pageSize = 10, string sortBy = "id");
        Task<ActionResult<object>> GetFiltredTrainerAsync(int page = 1, int pageSize = 10, string filter = "");
        Task<IEnumerable<PaymentDto>> GetPaymentsForMemberAsync(string userName);

        //biranje odgovarujuceg trenera
        Task<bool> ChooseTrainer(int memberId, int trainerId);
        Task<bool> CheckRating(int memberId, int trainerId);
        Task<bool> ResetSelectedTrainer(int memberId);
        Task<double> GetAverageRatingByTrainerId(int trainerId);
        Task<IEnumerable<TrainerUser>> GetPaginatedTrainersAsync(int page, int pageSize, int id);


        //prikaz svih clanarina 
        Task<IEnumerable<Membership>> GetMembershipsForMemberAsync(int memberId);

        //produzenje clanarine za naredni mesec
        Task<bool> ExtendMembershipAsync(int memberId, string newMembershipAmount, int targetMonth);
        //Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField);

        Task<IEnumerable<TrainerUser>> SortTrainersAsync(string sortByField, int page, int pageSize);


        //ocenjivanje trenera ocenom od 1 do 5
        Task<bool> RateTrainerAsync(int memberId, int trainerId, int ratingValue);
        Task<bool> HasSelectedTrainer(int memberId);
        Task<IEnumerable<Comment>> GetMemberCommentsAsync(int memberId);
    }
}
