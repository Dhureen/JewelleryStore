using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace JewelleryStore.Application
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, Unit>
    {
        private IUserDataAccess _userDataAccess;

        public DeleteUserCommandHandler(IUserDataAccess userDataAccess)
        {
            _userDataAccess = userDataAccess;
        }

        public async Task<Unit> Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            await _userDataAccess.Delete(command.Id);
            return Unit.Value;
        }
    }
}
