using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Zelda.Application.Commands.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, bool>
    {
        public Task<bool> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            request.Clients.Caller.hello();
            return Task.FromResult(true);
        }
    }
}
