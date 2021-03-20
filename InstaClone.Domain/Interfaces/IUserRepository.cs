using InstaClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface IUserRepository
    {
        Task Create(User user);
        User GetById(int id);
        Task UpdateUser(User user);
        Task<User> GetByNickname(string nickname);
        Task<User> GetByEmail(string email);
    }
}
