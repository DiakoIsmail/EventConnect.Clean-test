using EventConnect.Application.Features.Post.Commands.AddInterestedUserToPost;
using EventConnect.Application.Features.Post.Commands.CreatePost;
using EventConnect.Application.Features.Post.Commands.DeletePost;
using EventConnect.Application.Features.Post.Commands.UpdatePost;
using EventConnect.Application.Features.Post.Queries;
using EventConnect.Application.Features.Post.Queries.GetAllPosts;
using EventConnect.Application.Features.Post.Queries.GetPost;
using EventConnect.Domain.Entitys.Posts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EventConnect.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
//[Authorize]
public class PostController:ControllerBase
{
    private readonly IMediator _mediator;

    public PostController(IMediator mediator)
    {
        _mediator = mediator;
    }

    // GET: api/<PostController>
    [HttpGet]
    public async Task<List<GetAllPostDto>> Get()
    {
        var posts = await _mediator.Send(new GetAllPostQuery());
        return posts;
    }
    
    // GET api/<PostController>/5
    [HttpGet("{id}")]
    public async Task<ActionResult<GetSinglePostDto>> Get(int id)
    {
        var post = await _mediator.Send(new GetSinglePostQuery(id));
        return Ok(post);
    }
    
    // POST api/<CreatePostCommand>
    [HttpPost]
    [ProducesResponseType(201)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public  async Task<ActionResult> Post(CreatePostCommand post)
    {
        var response = await _mediator.Send(post);
        return CreatedAtAction(nameof(Get), new { id = response });
    }
    // POST api/<UpdatePostCommand>
    [HttpPut]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public  async Task<ActionResult> Put(UpdatePostCommand post)
    {
        await _mediator.Send(post);
        return NoContent();
    }
    
    // POST api/<DeletePostCommand>
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesDefaultResponseType]
    public async Task<ActionResult> Delete(int id)
    {
        await _mediator.Send(new DeletePostCommand{ Id = id });
        return NoContent();
    }
    
    // Put api/<AddInterestedUserToPostCommand>
    [HttpPut("AddInterestedUserToPost")]
    [ProducesResponseType(204)]
    [ProducesResponseType(400)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public  async Task<Post> AddInterestedUserToPost(AddInterestedUserToPostCommand post)
    {
      return  await _mediator.Send(post);
      
    }
}