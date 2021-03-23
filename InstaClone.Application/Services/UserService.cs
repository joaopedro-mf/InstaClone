using AutoMapper;
using InstaClone.Domain.Extensions;
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

        public async Task<IResponse> RegisterNewUser(UserInfoViewModel newUser)
        {
            User UserConverted = _mapper.Map<User>(newUser);

            UserConverted.AddErrors(CheckUserInfo(newUser));
            
            if (!UserConverted.haveError)
            {
                UserConverted.Validate();
                UserConverted.AddErrors(await CheckUserExists(UserConverted));

                if (!UserConverted.haveError)
                {
                    await _userRepository.Create(UserConverted);
                    return new Response<string>("Usuario Criado");
                }
            }
            return new Response<string>("User Information", UserConverted.Errors);
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
            UserPageViewModel userResponse = _mapper.Map<UserPageViewModel>(CheckUser); 

            return new Response<object>(new { user = userResponse, token = token }); 

        }

        public async Task<IResponse> UpdateUser(int id, UserInfoViewModel user)
        {
            User User = _mapper.Map<User>(user);
            User.Id = id;

            try
            {
                await _userRepository.UpdateUser(User);
                return new Response<string>("Sucesso, usuario adicionado com sucesso");
            }
            catch
            {
                return new Response<string>("Operação invalida", new Error("User Update", "Não foi possível atualiar o usario informado"));
            }

        }

        public async Task<IResponse> GetUserInfo(int id)
        {
            User User = await _userRepository.GetById(id);

            if(User.IsNullOrEmpty())
                return new Response<string>("Usuario não encontrado.");

            UserPageViewModel UserResponse = _mapper.Map<UserPageViewModel>(User);
            return new Response<UserPageViewModel>(UserResponse);
        }

        public async Task<IResponse> GetUserFullInfo(int id)
        {
            User UserResponse = await _userRepository.GetById(id);

            if (UserResponse.IsNullOrEmpty())
                return new Response<string>("Usuario não encontrado.");

            return new Response<User>(UserResponse);
        }
       
        public async Task<List<Error>> CheckUserExists(User userToCheck)
        {
            List<Error> Erros = new List<Error>();

            if (await _userRepository.GetByNickname(userToCheck.NickName) != null)
            {
                Erros.Add(new Error("User system", "Nickname já existe no sistema"));
            }
            if (await _userRepository.GetByEmail(userToCheck.Email) != null)
            {
                Erros.Add(new Error("User system", "Email já cadastrado no sistema"));
            }
            return Erros;
        }

        private List<Error> CheckUserInfo(UserInfoViewModel user)
        {
            List<Error> Erros = new List<Error>();

            if (user.Email.IsNullOrEmpty())
                Erros.Add(new Error("User Login", "Email não informado"));
            if (user.Password.IsNullOrEmpty())
                Erros.Add(new Error("User Login", "NickName não informado"));
            if (user.Password.IsNullOrEmpty())
                Erros.Add(new Error("User Login", "Senha não informado"));
            return Erros;

        }

        public async Task<IResponse> FollowUser(int followId, int userId)
        {
            try
            {
                User User = await _userRepository.GetById(userId);
                User UserToFollow = await _userRepository.GetById(followId);

                if (UserToFollow == null)
                    return new Response<string>("Usuario Invalido", new Error("User Follow", "Usuario não existe"));

                if (User.Following == null)
                    User.Following = new List<User>();

                User.Following.Add(UserToFollow);
                await _userRepository.UpdateUser(User);

                return new Response<string>("Sucesso");

            }
            catch
            {
                return new Response<string>("Operação indisponivel", new Error("User Follow", "Não foi possível realizar operação"));
            }


        }
    }
}
