using AutoMapper;
using InstaClone.Domain.Models;
using InstaClone.Domain.ViewModels;
using InstaClone.Domain.ViewModels.Comment;
using InstaClone.Domain.ViewModels.Post;
using InstaClone.Domain.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace InstaClone.Application.AutoMapper
{
    public class DomainToViewModelMap : Profile
    {
        public DomainToViewModelMap()
        {
            CreateMap<User, UserViewModel>()
                    .ForMember(dest => dest.UserPhoto, m => m.MapFrom(a => a.UserPhoto.GetPhoto()));
            CreateMap<Post, PostViewModel>();
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
