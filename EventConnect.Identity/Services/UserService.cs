using System.Security.Claims;
using EventConnect.Application.Contracts;
using EventConnect.Domain.Models.Identity;
using EventConnectIdentity.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace EventConnect.Identity.Services;


public class UserService :IUserServices
{
    
    private readonly UserManager<ApplicationUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<ApplicationUser> userManager, IHttpContextAccessor _contextAccessor)
    {
        _userManager = userManager;
        this._contextAccessor = _contextAccessor;
    }



    public string UserId
    {
        get => _contextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
    }

    public Task<List<ApplicationUser>> GetApplicationUsers()
    {
        throw new NotImplementedException();
    }

    public async Task<User> GetUser(string userId)
    {
        var user = await _userManager.FindByIdAsync(userId);
        return new User
        {
            Email = user.Email,
            Id = user.Id,
            Firstname = user.FirstName,
            Lastname = user.LastName,
             ImageUrl= user.ImageUrl ?? "DefaultImageUrl", // provide a default image URL if user.ImageUrl is null
        };
    }

       

    public async Task<List<User>> GetUsers()
    {
        var employees = await _userManager.GetUsersInRoleAsync("EventConnectApplicationUser!åäö3!");
        return employees.Select(q => new User()
        {
            Id = q.Id,
            Email = q.Email,
            Firstname = q.FirstName,
            Lastname = q.LastName
        }).ToList();
    }
    
}