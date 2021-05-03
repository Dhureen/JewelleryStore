using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace JewelleryStore.Application
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, int>
    {
        private IUserDataAccess _userDataAccess;
        private IUserDomainFactory _userFactory;

        public CreateUserCommandHandler(IUserDataAccess userDataAccess, IUserDomainFactory userFactory)
        {
            _userDataAccess = userDataAccess;
            _userFactory = userFactory;
        }

        public async Task<int> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userFactory.Get(command);
            return await _userDataAccess.Create(user);
        }
    }
}
