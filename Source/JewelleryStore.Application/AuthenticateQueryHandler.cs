using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JewelleryStore.Model;
using MediatR;

namespace JewelleryStore.Application
{
    public class AuthenticateQueryHandler : IRequestHandler<AuthenticateQuery, AuthenticationTokenMessage>
    {
        private IUserDataAccess _userDataAccess;
        private IAuthenticationTokenGenerator _tokenGenerator;

        public AuthenticateQueryHandler(IUserDataAccess userDataAccess, IAuthenticationTokenGenerator tokenGenerator)
        {
            _userDataAccess = userDataAccess;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<AuthenticationTokenMessage> Handle(AuthenticateQuery query, CancellationToken cancellationToken)
        {
            var user = (await _userDataAccess.GetAll()).SingleOrDefault(x => x.Name == query.Name && x.Password == query.Password);

            if (user == null) return null;

            return _tokenGenerator.GenerateToken(user);
        }
    }
}
