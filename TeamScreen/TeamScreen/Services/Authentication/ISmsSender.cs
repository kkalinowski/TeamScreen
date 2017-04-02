using System.Threading.Tasks;

namespace TeamScreen.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
