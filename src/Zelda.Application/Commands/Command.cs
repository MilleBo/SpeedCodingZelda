using Microsoft.AspNet.SignalR.Hubs;

namespace Zelda.Application.Commands
{
    public abstract class Command<T>
    {
        protected Command(T request, IHubCallerConnectionContext<dynamic> clients)
        {
            Request = request;
            Clients = clients;
        }

        public T Request { get; set; }

        public IHubCallerConnectionContext<dynamic> Clients { get; set; }
    }
}
