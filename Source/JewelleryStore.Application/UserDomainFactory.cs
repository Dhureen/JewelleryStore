using System.Threading.Tasks;
using JewelleryStore.Domain;
using JewelleryStore.Model;

namespace JewelleryStore.Application
{
    public class UserDomainFactory : IUserDomainFactory
    {
        public async Task<User> Get(UserMessage userMessage)
        {
            var user = new User(userMessage.Id, userMessage.Name, userMessage.DiscountPercentage, GetUserType(userMessage.Type));
            return await Task.FromResult(user);
        }

        private UserType GetUserType(UserTypeMessage type)
        {
            switch (type)
            {
                case UserTypeMessage.Privileged: return UserType.Privileged;
                default: return UserType.Normal;
            }
        }
    }
}
