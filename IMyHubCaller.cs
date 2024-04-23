using System.Threading.Tasks;

namespace SignalR
{
    public interface IMyHubCaller
    {
        Task SendMessage(string message);
    }
}