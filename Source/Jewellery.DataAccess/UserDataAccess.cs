using System;
using System.Threading.Tasks;
using JewelleryStore.Application;
using JewelleryStore.Domain;
using JewelleryStore.Model;

namespace Jewellery.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        public Task<bool> Create(User user)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<UserMessage> Details(int id)
        {
            return id == 1
                ? await Task.FromResult(new UserMessage() { Id = 1, Name = "Normal", Type = UserTypeMessage.Normal })
                : await Task.FromResult(new UserMessage() { Id = 2, DiscountPercentage = 2, Name = "Privileged", Type = UserTypeMessage.Privileged });
        }

        public Task<bool> Update(User user)
        {
            throw new NotImplementedException();
        }
    }
}
