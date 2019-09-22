using MediatR;
using Microsoft.AspNet.SignalR.Hubs;
using Zelda.Common.Requests;

namespace Zelda.Application.Commands.Login
{
    public class LoginCommand : Command<LoginRequest>, IRequest<bool>
    {
        public LoginCommand(LoginRequest request, IHubCallerConnectionContext<dynamic> clients)
            : base(request, clients)
        {
        }
    }
}
