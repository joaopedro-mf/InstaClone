using InstaClone.Domain.Interfaces;
using InstaClone.Domain.ViewModels.Comment;
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
    public class CommentController : ApiController
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult> Create(CreateCommentViewModel commment) =>
        CustomResponse(await _commentService.CreateComment(commment, GetJwtIdentifier() ));

        [HttpDelete]
        [Authorize]
        [Route("id")]
        public async Task<ActionResult> Delete(int id) =>
            CustomResponse(await _commentService.DeleteComment(id, GetJwtIdentifier()));
    }
}
