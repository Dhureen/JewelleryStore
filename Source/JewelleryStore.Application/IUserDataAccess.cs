using System.Threading.Tasks;
using JewelleryStore.Domain;
using JewelleryStore.Model;

namespace JewelleryStore.Application
{
    public interface IUserDataAccess
    {
        Task<bool> Create(User user);
        Task<UserMessage> Details(int id);
        Task<bool> Update(User user);
        Task<bool> Delete(int id);
    }
}
