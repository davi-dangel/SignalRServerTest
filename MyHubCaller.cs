using Microsoft.AspNetCore.SignalR;
using SignalR;


class MyHubCaller : IMyHubCaller
{
    private readonly IHubContext<MyHub> _hubContext;

    public MyHubCaller(IHubContext<MyHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public async Task SendMessage(string message)
    {
        System.Console.WriteLine("Sending message");
        await _hubContext.Clients.All.SendAsync("ReceiveMessage", message);
    }
}