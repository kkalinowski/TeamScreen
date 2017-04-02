using System.Threading.Tasks;

namespace TeamScreen.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
