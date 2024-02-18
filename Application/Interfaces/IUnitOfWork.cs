namespace NBP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IAdministartorRepository AdministratorRepository { get; }
        IManagerRepository ManagerRepository { get; }
        IMemberRepository MemberRepository { get; }
        ITrainerRepository TrainerRepository { get; }
        IReceptionistRepository ReceptionistRepository { get; }
        IPhotoRepository PhotoRepository { get; }
        ILoginRepository LoginRepository { get; }
        ISellerRepository SellerRepository { get; }
        ISponsorRepository SponsorRepository { get; }
        IEmailSenderRepository EmailSenderRepository { get; }
        IUserInfoRepository UserInfoRepository { get; }
        Task<bool> SaveAsync();
    }
}
