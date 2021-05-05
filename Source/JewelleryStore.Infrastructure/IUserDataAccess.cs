using System.Collections.Generic;
using System.Threading.Tasks;
using JewelleryStore.Domain;
using JewelleryStore.Model;

namespace JewelleryStore.Infrastructure
{
    public interface IUserDataAccess
    {
        Task<int> Create(User user);
        Task<UserMessage> Details(int id);
        Task<int> Update(User user);
        Task Delete(int id);
        Task<IEnumerable<UserMessage>> Search(string query);
    }
}
