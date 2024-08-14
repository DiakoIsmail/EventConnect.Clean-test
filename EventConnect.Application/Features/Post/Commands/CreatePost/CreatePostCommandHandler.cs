using AutoMapper;
using EventConnect.Application.Contracts;
using EventConnect.Application.Contracts.Persistance;
using EventConnect.Application.Exceptions;
using EventConnect.Domain.Models.Identity;
using MediatR;

namespace EventConnect.Application.Features.Post.Commands.CreatePost;

public class CreatePostCommandHandler:IRequestHandler<CreatePostCommand, Domain.Entitys.Posts.Post>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IUserServices _userServices;

    public CreatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IUserServices userServices)
    {
        _mapper = mapper;
        _postRepository = postRepository;
        _userServices = userServices;
    }
    
    public async Task<Domain.Entitys.Posts.Post> Handle(CreatePostCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreatePostCommandValidator(_postRepository);
        var validationResult = await validator.ValidateAsync(request);

        if (validationResult.Errors.Any())
            throw new BadRequestException("Invalid Post Request", validationResult);

        User user = await _userServices.GetUser(request.UserId);
        if (user == null)
            throw new NotFoundException("User: ", request.UserId);
        
        var post = _mapper.Map<Domain.Entitys.Posts.Post>(request);
         post.UserId = user.Id;
         
         await _postRepository.CreateAsync(post);

         return post;
    }
}