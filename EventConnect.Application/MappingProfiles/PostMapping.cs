using AutoMapper;
using EventConnect.Application.Features.Post.Commands.CreatePost;
using EventConnect.Application.Features.Post.Commands.UpdatePost;
using EventConnect.Application.Features.Post.Queries;
using EventConnect.Application.Features.Post.Queries.GetAllPosts;

using EventConnect.Domain.Entitys.Posts;

namespace EventConnect.Application.MappingProfiles;

public class PostMapping:Profile
{
    public PostMapping()
    {
        CreateMap<GetAllPostDto, Post>().ReverseMap();
    
        CreateMap<GetPostDto, Post>().ReverseMap();
        CreateMap<CreatePostCommand, Post>().ReverseMap();
        CreateMap<UpdatePostCommand, Post>().ReverseMap();
        
        
     
        
    }
}