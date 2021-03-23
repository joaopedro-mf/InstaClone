using InstaClone.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface ICommentRepository
    {
        Task Create(Comment comment);
        Task Delete(int id);
        Task<bool> CheckPermission(int commentId, int userId);
    }
}
