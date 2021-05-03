using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JewelleryStore.Application;
using JewelleryStore.Domain;
using JewelleryStore.EntityModel;
using JewelleryStore.Model;
using Microsoft.EntityFrameworkCore;

namespace Jewellery.DataAccess
{
    public class UserDataAccess : IUserDataAccess
    {
        private IMapper _mapper;
        private IDbContextFactory<JewelleryStoreContext> _contextFactory;

        public UserDataAccess(IDbContextFactory<JewelleryStoreContext> context, IMapper mapper)
        {
            _contextFactory = context;
            _mapper = mapper;
        }

        public async Task<int> Create(User user)
        {
            using (var context = _contextFactory.CreateDbContext())
            {

                context.UserProfiles.Add(_mapper.Map<UserProfile>(user) );
                return await Task.FromResult(context.SaveChanges());
            }

        }

        public async Task Delete(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == id);
                context.Remove(userProfile);
                await Task.FromResult(context.SaveChanges());
            }
        }

        public async Task<UserMessage> Details(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var userProfile = await Task.FromResult(context.UserProfiles.FirstOrDefault(x => x.Id == id));
                return _mapper.Map<UserMessage>(userProfile);
            }
        }

        public async Task<int> Update(User user)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var userProfile = context.UserProfiles.FirstOrDefault(x => x.Id == user.Id);
                userProfile = _mapper.Map<UserProfile>(user);
                return await Task.FromResult(context.SaveChanges());
            }
        }
    }
}
