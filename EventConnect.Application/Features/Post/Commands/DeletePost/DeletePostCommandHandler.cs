using EventConnect.Application.Contracts.Persistance;
using MediatR;

namespace EventConnect.Application.Features.Post.Commands.DeletePost;

public class DeletePostCommandHandler: IRequestHandler<DeletePostCommand, Unit>
{
    private readonly IPostRepository _postRepository;

    public DeletePostCommandHandler(IPostRepository postRepository)
    {
        _postRepository = postRepository;
    }
    
    public async Task<Unit> Handle(DeletePostCommand request, CancellationToken cancellationToken)
    {
        // Retrieve the post from the repository using the Id from the request
        var post = await _postRepository.GetByIdAsync(request.Id);

        // Delete the retrieved post from the repository
        await _postRepository.DeleteAsync(post);

        // Return Unit.Value to signify that the operation has completed successfully
        return Unit.Value;
    }
}