using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNet.SignalR;
using Microsoft.Practices.Unity;
using Zelda.Application.Commands.Login;
using Zelda.Common.Requests;
using IRequest = MediatR.IRequest;

namespace Zelda.Server.Hubs
{
    public class GameHub : Hub
    {
        private static IUnityContainer _unityContainer;
        private static IMediator _mediator;

        public override Task OnConnected()
        {
            Console.WriteLine("New connection..");

            if (_unityContainer == null)
            {
                _unityContainer = Bootstrapper.GetContainer();
                _mediator = _unityContainer.Resolve<IMediator>();
            }

            return base.OnConnected();
        }

        public void Login(LoginRequest request)
        {
            _mediator.Send(new LoginCommand(request, Clients));
        }
    }
}