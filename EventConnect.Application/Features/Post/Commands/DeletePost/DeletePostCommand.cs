using MediatR;

namespace EventConnect.Application.Features.Post.Commands.DeletePost;

public class DeletePostCommand:IRequest<Unit>
{
    public int Id { get; set; }
}