using AutoMapper;
using InstaClone.Domain.Extensions;
using InstaClone.Domain.Interfaces;
using InstaClone.Domain.Models;
using InstaClone.Domain.SeedWork;
using InstaClone.Domain.ViewModels.Comment;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InstaClone.Application.Services
{
    public class CommentService : ICommentService
    {
        private readonly IMapper _mapper;
        private readonly ICommentRepository _commentRepository;

        public CommentService(IMapper mapper,
                            ICommentRepository repository)
        {
            _mapper = mapper;
            _commentRepository = repository;
        }
        public async Task<IResponse> CreateComment(CreateCommentViewModel comment, int userId)
        {
            if(comment.UserId != userId)
                return new Response<string>("Sem permissão", new Error("Create Comment", "Usuario não possui permissão para realizar operação"));

            Comment NewComment = _mapper.Map<Comment>(comment);
            NewComment.AddErrors(CheckComment(comment));

            if (NewComment.haveError)
            {
                return new Response<string>("Comment Create", NewComment.Errors);
            }

            await _commentRepository.Create(NewComment);
            return new Response<string>("Comentario Adicionado");
        }

        public async Task<IResponse> DeleteComment(int id, int userId)
        {
            if(!await _commentRepository.CheckPermission(id, userId))
                return new Response<string>("Sem permissão", new Error("Delete Comment", "Usuario não possui permissão para realizar operação"));

            await _commentRepository.Delete(id);
            return new Response<string>("Comentario Excluido");
        }

        private List<Error> CheckComment(CreateCommentViewModel comment)
        {
            List<Error> Erros = new List<Error>();

            if (comment.UserId.IsNullOrEmpty())
                Erros.Add(new Error("Create Comment", "Usuario não informado"));
            if (comment.PostId.IsNullOrEmpty())
                Erros.Add(new Error("Create Comment", "Post não Informado"));
            if (comment.CommentText.IsNullOrEmpty())
                Erros.Add(new Error("Create Comment", "Comentario invalido"));

            return Erros;
        }
    }
}
