using System.Threading.Tasks;

namespace Rwby.Global.Web.Services
{
    public interface ISmsSender
    {
        Task SendSmsAsync(string number, string message);
    }
}
