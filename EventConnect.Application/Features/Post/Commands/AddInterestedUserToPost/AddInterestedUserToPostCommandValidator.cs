using EventConnect.Application.Contracts;
using EventConnect.Application.Contracts.Persistance;
using FluentValidation;

namespace EventConnect.Application.Features.Post.Commands.AddInterestedUserToPost;

public class AddInterestedUserToPostCommandValidator: AbstractValidator<AddInterestedUserToPostCommand>
{
    private readonly IPostRepository _postRepository;
    private readonly IUserServices _userServices;

    public AddInterestedUserToPostCommandValidator(IPostRepository postRepository, IUserServices userServices)
    {
        _postRepository = postRepository;
        _userServices = userServices;
        
        
        RuleFor(p => p.PostId)
            .GreaterThan(0)
            .NotNull()
            .MustAsync(PostMustExist).WithMessage("Post does not exist");
       /* 
        RuleFor(p => p.InterestedUserId)
            .NotNull()
            .MustAsync(UserMustExist).WithMessage("User does not exist");
    */
    }
    
    
       
    private async Task<bool> PostMustExist(int postId, CancellationToken cancellationToken)
    {
        var post = await _postRepository.GetByIdAsync(postId);
        Console.WriteLine(post);
        return post != null;
    }
    
    // cheek if user exsists    
    private async Task<bool> UserMustExist(String InterestedUserId, CancellationToken token)
    {
        
        try
        {
            var user = await _userServices.GetUser(InterestedUserId);
          Console.WriteLine(user);
            return user != null;
        }
        catch (Exception ex)
        {
            // Log the exception or handle it as needed
            return false;
        }
    }
    
 
}