using System.Threading.Tasks;

namespace Rwby.Identity.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
