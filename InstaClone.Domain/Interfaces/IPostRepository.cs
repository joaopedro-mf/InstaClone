using InstaClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface IPostRepository
    {
        Task Create(Post user);
        Task<Post> GetById(int id);
        Task Delete(int id);
        Task<bool> CheckPermission(int postId, int userId);
    }
}
