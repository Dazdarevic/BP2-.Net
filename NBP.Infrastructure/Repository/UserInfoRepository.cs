using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NBP.Domain.Identity;
using NBP.Infrastructure.Data;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;

namespace NBP.Infrastructure.Repository
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly DataContext dc;
        private readonly IMapper _mapper;

        public UserInfoRepository(DataContext dc, IMapper mapper)
        {
            this.dc = dc;
            _mapper = mapper;
        }

        public UserInfoDto GetUserByIdAndRole(int userId, string role)
        {
            User user = null;

            switch (role)
            {
                case "admin":
                    user = dc.Administrators.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "receptionist":
                    user = dc.Receptionists.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "trainer":
                    user = dc.Trainers.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "member":
                    user = dc.Members.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "manager":
                    user = dc.Managers.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "seller":
                    user = dc.Sellers.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                case "sponsor":
                    user = dc.Sponsors.AsNoTracking().FirstOrDefault(u => u.ID == userId);
                    break;
                default:
                    throw new ArgumentException("Nema takvog korisnika");
            }

            if (user == null)
            {
                return null;
            }

            UserInfoDto userInfoDto = _mapper.Map<UserInfoDto>(user);
            return userInfoDto;
        }

        public async Task UpdateProfilePictureUrlAsync(int userId, string role, string profilePictureUrl)
        {
            User user = null;

            switch (role.ToLower())
            {
                case "admin":
                    user = await dc.Administrators.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "receptionist":
                    user = await dc.Receptionists.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "trainer":
                    user = await dc.Trainers.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "member":
                    user = await dc.Members.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "manager":
                    user = await dc.Managers.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "seller":
                    user = await dc.Sellers.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                case "sponsor":
                    user = await dc.Sponsors.FirstOrDefaultAsync(u => u.ID == userId);
                    break;
                default:
                    throw new ArgumentException("Nema takvog korisnika");
            }

            if (user != null)
            {
                user.Url = profilePictureUrl;
                await dc.SaveChangesAsync();
            }
        }

    }
}
