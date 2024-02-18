using NBP.Application.Interfaces;
using NBP.Application.DTOs;
using System.Net;
using System.Net.Mail;

namespace NBP.Infrastructure.Repository
{
    public class EmailSenderRepository : IEmailSenderRepository
    {
        public Task SendEmailAsync(string email, string subject, string message)
        {
            var client = new SmtpClient("smtp.office365.com", 587)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential("belkisa.dazdarevic1@gmail.com", "kvazilend5")
            };

            return client.SendMailAsync(
                new MailMessage(from: "belkisa.dazdarevic1@gmail.com",
                                to: email,
                                subject,
                                message
                                ));
        }
    }
}
