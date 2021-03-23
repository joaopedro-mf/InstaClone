using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface IPostService
    {
        Task<IResponse> GetPost(int id);
        Task<IResponse> CreatePost(CreatePostViewModel post);
        Task<IResponse> DeletePost(int id, int userid);
    }
}
