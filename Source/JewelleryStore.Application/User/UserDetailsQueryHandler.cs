using System.Threading;
using System.Threading.Tasks;
using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class UserDetailsQuesryHandler : IRequestHandler<UserDetailsQuery, UserMessage>
    {
        private IUserDataAccess _userDataAccess;

        public UserDetailsQuesryHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<UserMessage> Handle(UserDetailsQuery command, CancellationToken cancellationToken)
        {
            return await _userDataAccess.Details(command.Id);            
        }
    }
}
