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
        public async Task<ActionResult> Register(CreateUserViewModel user) =>
            CustomResponse(await _userService.RegisterNewUser(user));

        [HttpPost]
        [Route("login")]
        public async Task<ActionResult> Login(UserLoginViewModel user) =>
            CustomResponse(await _userService.Login(user));

        [HttpPost]
        [Authorize]
        [Route("update/{id}")]
        public async Task<ActionResult> Update(int id,UserViewModel user) =>
            CustomResponse(await _userService.UpdateUser(id,user));

        [HttpGet]
        [Authorize]
        [Route("teste")]
        public string teste() =>
           //"teste";
           User.Identity.Name;

    }
}
