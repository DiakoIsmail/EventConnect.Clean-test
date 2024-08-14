using EventConnect.Application.Contracts.Persistance;
using EventConnect.Application.Features.Post.Commands.CreatePost;
using FluentValidation;

namespace EventConnect.Application.Features.Post.Commands.UpdatePost;

public class UpdatePostCommandValidator: AbstractValidator<UpdatePostCommand>
{

    private readonly IPostRepository _postRepository;

    public UpdatePostCommandValidator(IPostRepository postRepository)
    {

        _postRepository = postRepository;

        RuleFor(p => p.PostId)
            .NotNull()
            .MustAsync(PostMustExist)
            .WithMessage("Post with the given id does not exist.");

        // Add more rules for other properties as needed
        // For example:
        // RuleFor(p => p.Title)
        //     .NotEmpty()
        //     .WithMessage("Title is required.")
        //     .Length(1, 50)
        //     .WithMessage("Title must be between 1 and 50 characters.");
        //
        // RuleFor(p => p.Content)
        //     .NotEmpty()
        //     .WithMessage("Content is required.");
    }
    
    private async Task<bool> PostMustExist(int postId, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        return post != null;
    }
}