using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface ICommentService
    {
        Task<IResponse> CreateComment(CreateCommentViewModel post, int userId);
        Task<IResponse> DeleteComment(int id, int userId);
    }
}
