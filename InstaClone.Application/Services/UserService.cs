using AutoMapper;
using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper,
                            IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<IResponse> RegisterNewUser(CreateUserViewModel newUser)
        {
            User UserConverted = _mapper.Map<User>(newUser);
            UserConverted.Validate();
            UserConverted.AddErrors(await CheckUserExists(UserConverted));


            if (UserConverted.haveError)
            {
                return new Response<string>("User Information", UserConverted.Errors);
            }

            await _userRepository.Create(UserConverted);

            return new Response<string>("Usuario Criado", UserConverted.Errors);

        }

        public async Task<IResponse> Login(UserLoginViewModel user)
        {
            User CheckUser = await _userRepository.GetByNickname(user.IdentificationName);
            if (CheckUser == null)
            {
                CheckUser = await _userRepository.GetByEmail(user.IdentificationName);
                if (CheckUser == null)
                    return new Response<string>("Usuario Inexistente", new Error("User Login", "Usuario Invalido"));  
            }

            string token = TokenService.GenerateToken(CheckUser);
            UserViewModel userResponse = _mapper.Map<UserViewModel>(CheckUser); 

            return new Response<object>(new { user = userResponse, token = token }); ;

        }

        public Task<IResponse> UpdateUser(int id, UserViewModel user)
        {
            throw new NotImplementedException();
        }

        public Task<IResponse> GetUserInfo(int id, UserViewModel user)
        {
            throw new NotImplementedException();
        }

        // so é possivel utilizar metodos de extensão quando a classe for static
        public async Task<List<Error>> CheckUserExists(User userToCheck)
        {
            List<Error> Erros = new List<Error>();

            if (await _userRepository.GetByNickname(userToCheck.NickName) == null)
            {
                Erros.Add(new Error("User system", "Nickname já exite no sistema"));
            }
            if (await _userRepository.GetByEmail(userToCheck.Email) == null)
            {
                Erros.Add(new Error("User system", "Email já cadastrado no sistema"));
            }
            return Erros;
        }

        public Task<IResponse> GetUserInfo(int id)
        {
            throw new NotImplementedException();
        }
    }
}
