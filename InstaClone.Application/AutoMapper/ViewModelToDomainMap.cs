using AutoMapper;
using InstaClone.Domain.Models;
using InstaClone.Domain.ValueObjects;
using InstaClone.Domain.ViewModels;
using InstaClone.Domain.ViewModels.Comment;
using InstaClone.Domain.ViewModels.Post;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Application.AutoMapper
{
    public class ViewModelToDomainMap : Profile
    {
        public ViewModelToDomainMap()
        {
            //TODO
            // Criar camada de Validação
            CreateMap<CreateUserViewModel, User>()
                .ForMember(dest => dest.Password, m => m.MapFrom(a => new Password(a.Password)))
                .ForMember(dest => dest.UserPhoto, m => m.MapFrom(a => new Photo(a.Photo_b64, a.NickName)));
            CreateMap<UserViewModel, User>();
            //.ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<PostViewModel, Post>();
            //  .ConstructUsing(c => new UpdateCustomerCommand(c.Id, c.Name, c.Email, c.BirthDate));
            CreateMap<CommentViewModel, Comment>();
        } 
    }
}
