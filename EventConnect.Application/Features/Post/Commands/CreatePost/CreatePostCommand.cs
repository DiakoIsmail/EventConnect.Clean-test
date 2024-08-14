using MediatR;

namespace EventConnect.Application.Features.Post.Commands.CreatePost;

public record CreatePostCommand:IRequest<Domain.Entitys.Posts.Post>
{
    public int PostId { get; set; }
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public string? ImageUrl { get; set; } 
    public string? UserId { get; set; } 
    public string? CategoryId { get; set; } 
    public string? Location { get; set; } 
    public string? City{ get; set; } 
    public string? Date { get; set; } 
    public string? Time { get; set; } 
   // public  List<string>?  InterestedUsersIds  = new List<string>();
}