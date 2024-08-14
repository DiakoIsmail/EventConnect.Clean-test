using MediatR;

namespace EventConnect.Application.Features.Post.Commands.AddInterestedUserToPost;

public record AddInterestedUserToPostCommand : IRequest<Domain.Entitys.Posts.Post>
{
    public int PostId { get; set; }
    public string? InterestedUserId { get; set; } 
}