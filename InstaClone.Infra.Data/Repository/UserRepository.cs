using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Infra.Data.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(InstaContext dbContext) :base(dbContext) { }

        public async  Task<User> GetByEmail(string email)
        {
            return await _dbContext.Set<User>()
                                .FirstOrDefaultAsync(p => p.Email == email);
        }

        public async Task<User> GetByNickname(string nickname)
        {
            return await _dbContext.Set<User>()
                                .FirstOrDefaultAsync(p=>p.NickName == nickname);
        }

        public Task Create(User newUser) =>
            base.Insert(newUser);

        public User GetById(int id) => 
            base.Select(id);

        public Task UpdateUser(User user) =>
            base.Update(user);

    }
}