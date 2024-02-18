namespace NBP.Application.Interfaces
{
    public interface IEmailSenderRepository
    {
        Task SendEmailAsync(string email, string subject, string message);

    }
}
