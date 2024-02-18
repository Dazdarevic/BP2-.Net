using AutoMapper;
using Microsoft.Extensions.Options;
using NBP.Application.Interfaces;
using NBP.Infrastructure.Repository;
using NBP.Domain.Entities;
using NBP.Infrastructure.Data;

namespace NBP.API.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dc;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly IOptions<CloudinarySettings> _cloudinaryConfig;
        public UnitOfWork(DataContext dc, IMapper mapper, IConfiguration configuration, IOptions<CloudinarySettings> cloudinaryConfig)
        {
            this.dc = dc;
            this._mapper = mapper;
            _configuration = configuration;
            _cloudinaryConfig = cloudinaryConfig;
        }
        public IAdministartorRepository AdministratorRepository
            => new AdministratorRepository(dc);
        public IManagerRepository ManagerRepository
            => new ManagerRepository(dc);
        public IMemberRepository MemberRepository
            => new MemberRepository(dc);

        public ITrainerRepository TrainerRepository
            => new TrainerRepository(dc);
        public IReceptionistRepository ReceptionistRepository
            => new ReceptionistRepository(dc);
        public IPhotoRepository PhotoRepository
            => new PhotoRepository(_cloudinaryConfig);
        public ILoginRepository LoginRepository
            => new LoginRepository(dc, _configuration);
        public ISellerRepository SellerRepository
            => new SellerRepository(dc);
        public ISponsorRepository SponsorRepository
            => new SponsorRepository(dc);
        public IEmailSenderRepository EmailSenderRepository
            => new EmailSenderRepository();
        public IUserInfoRepository UserInfoRepository
            => new UserInfoRepository(dc, _mapper);

        public async Task<bool> SaveAsync()
        {
            return await dc.SaveChangesAsync() > 0;
        }
    }
}
