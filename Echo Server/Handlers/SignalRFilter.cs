using Microsoft.AspNetCore.SignalR;

namespace Echo_Server.Handlers
{
    public class SignalRFilter : IHubFilter
    {

        // Optional method
        public Task OnConnectedAsync(HubLifetimeContext context, Func<HubLifetimeContext, Task> next)
        {
            Console.WriteLine("Client Connected");
            return next(context);
        }

        // Optional method
        public Task OnDisconnectedAsync(
            HubLifetimeContext context, Exception exception, Func<HubLifetimeContext, Exception, Task> next)
        {
            Console.WriteLine("Client Disconnected");
            return next(context, exception);
        }
    }
}
