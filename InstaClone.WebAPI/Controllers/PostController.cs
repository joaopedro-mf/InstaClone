using InstaClone.Domain.Interfaces;
using InstaClone.Domain.ViewModels.Post;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InstaClone.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ApiController
    {
        private readonly IPostService _postService;
        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult> Get(int id) =>
            CustomResponse(await _postService.GetPost(id));

        [HttpPost]
        //[Authorize]
        public async Task<ActionResult> Create(CreatePostViewModel post) =>
            CustomResponse(await _postService.CreatePost( post));

        [HttpDelete]
        [Authorize]
        [Route("id")]
        public async Task<ActionResult> Delete(int id) =>
            CustomResponse(await _postService.DeletePost(id, GetJwtIdentifier()));

    }
}
