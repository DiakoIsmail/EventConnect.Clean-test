using AutoMapper;
using EventConnect.Application.Contracts;
using EventConnect.Application.Contracts.Persistance;
using EventConnect.Application.Exceptions;
using MediatR;

namespace EventConnect.Application.Features.Post.Commands.UpdatePost;

public class UpdatePostCommandHandler: IRequestHandler<UpdatePostCommand, Domain.Entitys.Posts.Post>
{
                private readonly IMapper _mapper;
                private readonly IPostRepository _postRepository;
                private readonly IUserServices _userServices;

                public UpdatePostCommandHandler(IMapper mapper, IPostRepository postRepository, IUserServices userServices)
                {
                    _mapper = mapper;
                    _postRepository = postRepository;
                    _userServices = userServices;
                }
                
                public async Task<Domain.Entitys.Posts.Post> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
                {
                    // Create a new instance of the UpdatePostCommandValidator passing the post repository to its constructor
                    var validator = new UpdatePostCommandValidator(_postRepository);

                    // Validate the request asynchronously using the validator
                    var validationResult = await validator.ValidateAsync(request);

                    // If there are any validation errors, throw a BadRequestException with the validation result
                    if (validationResult.Errors.Any())
                        throw new BadRequestException("Invalid Post Request", validationResult);
    
                    // Get the post from the repository asynchronously using the PostId from the request
                    var post = await _postRepository.GetByIdAsync(request.PostId);

                    // If the post does not exist, throw a NotFoundException
                    if (post == null)
                        throw new NotFoundException("Post", request.PostId);
    
                    // Get the user from the user services asynchronously using the UserId from the request
                    var user = await _userServices.GetUser(request.UserId);

                    // If the user does not exist, throw a NotFoundException
                    if (user == null)
                        throw new NotFoundException("User", request.UserId);
    
                    // Map the request to the post object using the mapper
                    post = _mapper.Map(request, post);

                    // Set the UserId of the post to the Id of the user
                    post.UserId = user.Id;
                    post.DateModified = DateTime.Now;
    
                    // Update the post in the repository asynchronously
                    await _postRepository.UpdateAsync(post);
    
                    // Return the updated post
                    return post;
                }
}