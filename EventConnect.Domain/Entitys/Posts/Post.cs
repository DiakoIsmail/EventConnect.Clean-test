using System.ComponentModel.DataAnnotations;
using EventConnect.Domain.Common;
using EventConnect.Domain.Models.Identity;

namespace EventConnect.Domain.Entitys.Posts;
// a class that represents a post 

public class Post:BaseEntity
{
    public string? Name { get; set; } 
    public string? Description { get; set; } 
    public string? ImageUrl { get; set; } 
    public string? UserId { get; set; } 
    public string? CategoryId { get; set; } 
    public string? Location { get; set; } 
    public string? City{ get; set; } 
    public string? Date { get; set; } 
    public string? Time { get; set; } 
    
   
    public ICollection<User> Interested_users { get; set; } 
 
    
   
}

