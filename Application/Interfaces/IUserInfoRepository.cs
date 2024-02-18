using NBP.Application.DTOs;

namespace NBP.Application.Interfaces
{
    public interface IUserInfoRepository
    {
        UserInfoDto GetUserByIdAndRole(int userId, string role);
        Task UpdateProfilePictureUrlAsync(int userId, string role, string profilePictureUrl);

    }
}
