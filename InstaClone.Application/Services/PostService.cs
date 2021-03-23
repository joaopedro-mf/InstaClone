using AutoMapper;
using InstaClone.Domain.Extensions;
using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.Post;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Application.Services
{
    public class PostService : IPostService
    {
        private readonly IMapper _mapper;
        private readonly IPostRepository _postRepository;

        public PostService(IMapper mapper,
                            IPostRepository repository, IUserRepository tesUser)
        {
            _mapper = mapper;
            _postRepository = repository;
        }
        public async Task<IResponse> CreatePost(CreatePostViewModel post)
        {
            Post NewPost = _mapper.Map<Post>(post);
            NewPost.Validate();

            if(NewPost.haveError)
                return new Response<string>("Create Post", NewPost.Errors);

            await _postRepository.Create(NewPost);
            return new Response<string>("Post Criado");

        }

        public async Task<IResponse> DeletePost(int id , int userId)
        {
            if (! await _postRepository.CheckPermission(id, userId))
                return new Response<string>("Sem permissão", new Error("Post Delete", "Usuario não possui permissão para realizar operação"));

            await _postRepository.Delete(id);
            return new Response<string>("Post Excluido");
        }

        public async Task<IResponse> GetPost(int id)
        {
            try
            {
                Post Post = await _postRepository.GetById(id);
                return new Response<Post>(Post);
            }
            catch
            {
                return new Response<string>("Post Inexistente");
            }
            
            //if(id.IsNullOrEmpty())
            //    return new Response<string>("Post Inexistente");

            ////PostPageViewModel PostResponse = _mapper.Map<PostPageViewModel>(Post);

            //return new Response<Post>(Post);
        }
    }
}
