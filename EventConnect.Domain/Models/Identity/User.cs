

using EventConnect.Domain.Common;
using EventConnect.Domain.Entitys.Posts;

namespace EventConnect.Domain.Models.Identity;

public class User:BaseEntity
{
    public string Id { get; set; }
    public string  Email { get; set; }= String.Empty;
    public string Firstname { get; set; }= String.Empty;
    public string Lastname { get; set; }= String.Empty;
    
    public string ImageUrl { get; set; }
    
    public ICollection<Post> Posts { get; set; } 
   
}