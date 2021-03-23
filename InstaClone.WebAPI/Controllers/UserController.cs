using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Domain.ViewModels.User;
using InstaClone.WebAPI.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register(UserInfoViewModel user) =>
            CustomResponse(await _userService.RegisterNewUser(user));

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLoginViewModel user) =>
            CustomResponse(await _userService.Login(user));

        [HttpPut]
        [Authorize]
        public async Task<ActionResult> Update(UserInfoViewModel user) =>
            CustomResponse(await _userService.UpdateUser( GetJwtIdentifier() , user));

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult> GetInfo(int id) =>
            CustomResponse(await _userService.GetUserInfo(id));

        [HttpGet]
        [Authorize]
        [Route("{id}/full")]
        public async Task<ActionResult> GetFullInfo() =>
        CustomResponse(await _userService.GetUserFullInfo( GetJwtIdentifier() ));

        [HttpPost]
        [Authorize]
        [Route("{id}/follow")]
        public async Task<ActionResult> Follow(int id) =>
        CustomResponse(await _userService.FollowUser(id, GetJwtIdentifier()));

    }
}
