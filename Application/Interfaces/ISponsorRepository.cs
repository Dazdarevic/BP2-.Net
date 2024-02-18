using NBP.Domain.Entities;

namespace NBP.Application.Interfaces
{
    public interface ISponsorRepository
    {
        void AddAd(Advertisement ad);
        Task<IEnumerable<Advertisement>> GetAllAdsAsync();


    }
}
