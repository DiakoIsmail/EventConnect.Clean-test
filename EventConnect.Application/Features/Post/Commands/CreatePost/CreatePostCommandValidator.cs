using EventConnect.Application.Contracts.Persistance;
using FluentValidation;

namespace EventConnect.Application.Features.Post.Commands.CreatePost;

public class CreatePostCommandValidator: AbstractValidator<CreatePostCommand>
{

    private readonly IPostRepository _postRepository;

    public CreatePostCommandValidator(IPostRepository postRepository)
    {

        RuleFor(p => p.PostId)
            .GreaterThan(0)
            .NotNull();
        
        
        _postRepository = postRepository;
    }
    
    private async Task<bool> PostMustExist(CreatePostCommand command, CancellationToken token)
    {
        var post = await _postRepository.GetByIdAsync(command.PostId);
        return post != null;
    }
}