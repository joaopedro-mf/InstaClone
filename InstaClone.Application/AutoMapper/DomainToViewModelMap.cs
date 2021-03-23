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
            CreateMap<User, UserPageViewModel>()
                    .ForMember(dest => dest.UserPhoto, m => m.MapFrom(a => a.UserPhoto.GetPhoto()))
                    .ForMember(dest => dest.UserId, m => m.MapFrom(a => a.Id));
            CreateMap < User,UserIconViewModel>()
                .ForMember(dest => dest.UserPhoto, m => m.MapFrom(a => a.UserPhoto.GetPhoto()));
            CreateMap<Post, PostPageViewModel>()
                .ForMember(dest => dest.Photo, m => m.MapFrom(a => a.PostImage.GetPhoto()))
                .ForMember(dest => dest.Location, m => m.MapFrom(a => a.Local.GetValue()));
            CreateMap<Comment, CommentViewModel>();
        }
    }
}
