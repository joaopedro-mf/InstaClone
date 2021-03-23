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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        public PostRepository(InstaContext dbContext) : base(dbContext) { }

        public Task Create(Post post) =>
            base.Insert(post);
        public async Task<Post> GetById(int id)
        {
            var db = _dbContext.Set<Post>();
            List<Post> teste = await db.ToListAsync();
                Post Post = await _dbContext.Set<Post>().FirstOrDefaultAsync(p => p.Id == id);
                return Post;
        }

        public Task Delete(int id) =>
             base.Delete(id);

        public async Task<bool> CheckPermission(int postId, int userId)
        {
            Post Post = await _dbContext.Set<Post>().FirstOrDefaultAsync(p =>  p.Id == postId && p.UserId == userId);
            return Post != null;
        }
    }
}
