using NBP.Application.DTOs;
using NBP.Domain.Identity;

namespace NBP.Application.Interfaces
{
    public interface ITrainerRepository
    {
        //pregled liste clanova
        Task<IEnumerable<Member>> GetAllMembersAsync();
        Task<IEnumerable<MemberInfoDto>> GetAllMembersByManager();

        Task<IEnumerable<Member>> GetMembersWithSelectedTrainerAsync(int trainerId);
        Task<bool> AddOrUpdateCommentAsync(CommentDto comment);
        Task<CommentDto> GetCommentByTrainerAndMemberIdAsync(int trainerId, int memberId);
        Task<CommentDto> GetCommentByMemberIdAsync(int memberId);
    }
}
