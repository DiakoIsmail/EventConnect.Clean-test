using AutoMapper;
using EventConnect.Application.Contracts.Logging;
using EventConnect.Application.Contracts.Persistance;
using MediatR;

namespace EventConnect.Application.Features.Post.Queries.GetAllPosts;

public class GetPostQueryHandler:IRequestHandler<GetAllPostQuery, List<GetAllPostDto>>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;


    public GetPostQueryHandler(IMapper mapper, IPostRepository postRepository)
    {
        _mapper = mapper;
        _postRepository = postRepository;
       
    }
    
    public async Task<List<GetAllPostDto>> Handle(GetAllPostQuery request, CancellationToken cancellationToken)
    {//Query the database
        var posts = await _postRepository.GetAllAsync();
        //convert data objects to DTO objects
        var data = _mapper.Map<List<GetAllPostDto>>(posts);
     
        //return list of Dto  object
        return data;
    }
}