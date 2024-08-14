
using EventConnect.Domain.Models.Identity;

namespace EventConnect.Application.Contracts;

public interface IUserServices
{
    Task<List<User>> GetUsers();
    Task<User> GetUser(string id );
    

    
    
    public string UserId { get;  }
}