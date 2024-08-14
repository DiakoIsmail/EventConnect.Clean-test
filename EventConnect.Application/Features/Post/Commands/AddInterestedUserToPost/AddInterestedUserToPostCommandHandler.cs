using System.Security.Cryptography;
using AutoMapper;
using EventConnect.Application.Contracts;
using EventConnect.Application.Contracts.Persistance;
using EventConnect.Application.Exceptions;
using EventConnect.Domain.Models.Identity;
using FluentValidation;
using MediatR;

namespace EventConnect.Application.Features.Post.Commands.AddInterestedUserToPost;

public class AddInterestedUserToPostCommandHandler: IRequestHandler<AddInterestedUserToPostCommand, Domain.Entitys.Posts.Post>
{
    private readonly IMapper _mapper;
    private readonly IPostRepository _postRepository;
    private readonly IUserServices _userServices;
    private readonly IUserRepository _userRepository;


    public AddInterestedUserToPostCommandHandler(IPostRepository postRepository, IUserServices userServices, IMapper mapper, IUserRepository userRepository)
    {
        _postRepository = postRepository;
        _userServices = userServices;
        _mapper = mapper;
        _userRepository = userRepository;
    }
    
    public async Task<Domain.Entitys.Posts.Post> Handle(AddInterestedUserToPostCommand request, CancellationToken cancellationToken)
    {
        // Create a new instance of the AddInterestedUserToPostCommandValidator passing the post repository to its constructor
       // var validator = new AddInterestedUserToPostCommandValidator(_postRepository, _userServices);

        // Validate the request asynchronously using the validator
     //  var validationResult = await validator.ValidateAsync(request);

        // If there are any validation errors, throw a BadRequestException with the validation result
       //if (validationResult.Errors.Any())
      //     throw new BadRequestException("Invalid Post Request", validationResult);
        //-----------------------------------------------------------------------------------------------------

        User user = await _userServices.GetUser(request.InterestedUserId);
        Console.WriteLine(user);
        
    // using ApplicationUser  and Post as a reference . Create a connection between existing post and existing ApplicationUser 
        var post = await _postRepository.GetByIdAsync(request.PostId);
        Console.WriteLine(post);
        
        User Connecting = new User
        {
            Id = user.Id,
            Email = user.Email ?? string.Empty,
            Firstname = user.Firstname ?? string.Empty,
            Lastname = user.Lastname ?? string.Empty,
            ImageUrl = user.ImageUrl ?? "DefaultImageUrl", // provide a default image URL if user.ImageUrl is null
            DateCreated = DateTime.Now,
            CreatedBy = user.Id ?? string.Empty,
            DateModified = DateTime.Now,
            ModifiedBy = user.Id ?? string.Empty,
        };

        post.Interested_users.Add(Connecting);
        Connecting.Posts.Add(post);
        await _userRepository.CreateAsync(Connecting);
        await _postRepository.CreateAsync(post);
        

        return post;
    }
}