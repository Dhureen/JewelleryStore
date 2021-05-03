using System.Threading.Tasks;
using JewelleryStore.Domain;
using JewelleryStore.Model;

namespace JewelleryStore.Application
{
    public interface IUserDomainFactory
    {
        Task<User> Get(UserMessage userMessage);
    }
}
