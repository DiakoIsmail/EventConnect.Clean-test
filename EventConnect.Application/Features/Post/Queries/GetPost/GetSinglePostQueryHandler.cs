using AutoMapper;
using EventConnect.Application.Contracts.Logging;
using EventConnect.Application.Contracts.Persistance;
using EventConnect.Application.Exceptions;
using MediatR;

namespace EventConnect.Application.Features.Post.Queries.GetPost;

public class GetSinglePostQueryHandler:IRequestHandler<GetSinglePostQuery, GetSinglePostDto>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
 
    
    public GetSinglePostQueryHandler(IMapper mapper, IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
    
    }

    public async Task<GetSinglePostDto> Handle(GetSinglePostQuery request, CancellationToken cancellationToken)
    {
        // Query database for single post
        var post = await _postRepository.GetByIdAsync(request.Id);
        
        // Verify record exsists in database
        if (post == null)
            throw new NotFoundException(nameof(Post), request.Id);
        
        // Convert data object to DTO object
        var data = _mapper.Map<GetSinglePostDto>(post);
        
        // Return DTO object
        return data;
    }
}