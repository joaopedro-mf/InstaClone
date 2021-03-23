using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Infra.Data.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        public CommentRepository(InstaContext dbContext) : base(dbContext) { }

        public async Task<bool> CheckPermission(int commentId, int userId)
        {
            Comment Commment = await _dbContext.Set<Comment>()
                    .FirstOrDefaultAsync(p => p.Id == commentId && p.UserId == userId);
            return Commment != null;
        }

        public Task Create(Comment comment) =>
            base.Insert(comment);
        public Task Delete(int id) =>
            base.Delete(id);
    }
}
