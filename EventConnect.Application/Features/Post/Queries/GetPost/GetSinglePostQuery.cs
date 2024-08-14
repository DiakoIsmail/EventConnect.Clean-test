using MediatR;

namespace EventConnect.Application.Features.Post.Queries.GetPost;

public record GetSinglePostQuery(int Id):IRequest<GetSinglePostDto>
{
    
}