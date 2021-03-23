using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Domain.Interfaces
{
    public interface IUserService
    {
        Task<IResponse> RegisterNewUser(UserInfoViewModel user);
        Task<IResponse> Login(UserLoginViewModel user);
        Task<IResponse> UpdateUser(int id, UserInfoViewModel user);
        Task<IResponse> GetUserInfo(int id);
        Task<IResponse> GetUserFullInfo(int id);
        Task<IResponse> FollowUser(int followId, int userId);
    }
}
