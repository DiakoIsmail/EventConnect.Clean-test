using MediatR;

namespace EventConnect.Application.Features.Post.Queries.GetAllPosts;

public record GetAllPostQuery : IRequest<List<GetAllPostDto>>;
