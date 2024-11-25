using AutoMapper;
using DemoPosts.Application.Features.Posts.Commands.CreatePost;
using DemoPosts.Application.Features.Posts.Commands.DeletePost;
using DemoPosts.Application.Features.Posts.Queries.GetPostDetail;
using DemoPosts.Application.Features.Posts.Queries.GetPostsList;
using DemoPosts.Domain;

namespace DemoPosts.Application.Profiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Post, GetPostsListViewModel>().ReverseMap();
            CreateMap<Post, GetPostDetailViewModel>().ReverseMap();
            CreateMap<CreatePostCommand, Post>().ReverseMap();
            CreateMap<DeletePostCommand, Post>().ReverseMap();
        }
    }
}
