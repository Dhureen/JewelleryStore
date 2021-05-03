using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace JewelleryStore.Application
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, int>
    {
        private IUserDataAccess _userDataAccess;
        private IUserDomainFactory _userFactory;

        public UpdateUserCommandHandler(IUserDataAccess userDataAccess, IUserDomainFactory userFactory)
        {
            _userDataAccess = userDataAccess;
            _userFactory = userFactory;
        }

        public async Task<int> Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var user = await _userFactory.Get(command);
            return await _userDataAccess.Update(user);
        }
    }
}
