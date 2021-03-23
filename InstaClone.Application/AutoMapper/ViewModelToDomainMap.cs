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
            CreateMap<UserInfoViewModel, User>()
                .ForMember(dest => dest.Password, m => m.MapFrom(a => new Password(a.Password)))
                .ForMember(dest => dest.UserPhoto, m => m.MapFrom(a => new Photo(a.Photo, a.NickName)));
            CreateMap<UserPageViewModel, User>();
            //.ConstructUsing(c => new RegisterNewCustomerCommand(c.Name, c.Email, c.BirthDate));
            CreateMap<PostCardViewModel, Post>();
            CreateMap<CreatePostViewModel, Post>()
                .ForMember(dest => dest.PostImage, m => m.MapFrom(a => new Photo(a.Photo, a.UserId)))
                .ForMember(dest => dest.Local, m => m.MapFrom(a => new Location(a.Location)))
                .ForMember(dest => dest.Description, m => m.MapFrom(a => a.Descritpion));
            CreateMap<CreateCommentViewModel, Comment>()
                .ForMember(dest => dest.Description, m => m.MapFrom(a => a.CommentText));
        } 
    }
}
