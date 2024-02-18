using Microsoft.EntityFrameworkCore;
using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using NBP.Domain.Entities;
using NBP.Infrastructure.Data;

namespace NBP.Infrastructure.Repository
{
    public class SponsorRepository : ISponsorRepository
    {
        private readonly DataContext dc;

        public SponsorRepository(DataContext dc)
        {
            this.dc = dc;
        }
        public void AddAd(Advertisement ad)
        {
            dc.Advertisements.Add(ad);
        }

        public async Task<IEnumerable<Advertisement>> GetAllAdsAsync()
        {
            return await dc.Advertisements.ToListAsync();
        }

    }
}
