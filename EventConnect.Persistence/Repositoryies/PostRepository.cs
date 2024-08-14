using EventConnect.Application.Contracts.Persistance;
using EventConnect.Domain.Entitys.Posts;
using EventConnect.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace EventConnect.Persistence.Repositoryies;

public class PostRepository: GenericRepository<Post>, IPostRepository
{
    public PostRepository(EcDatabaseContext context) : base(context)
    {
    }

    public async  Task<bool> PostExists(string userID, int postId)
    {
       return _context.Posts.Any(q => q.UserId == userID && q.Id == postId);
       
    }

    public async Task<List<Post>> GetPostsByUserId(string userId)
    {
        return await _context.Posts.Where(q => q.UserId == userId).ToListAsync();
    }

    public async Task<List<Post>> GetPosts()
    {
         return await _context.Posts.ToListAsync();
    }

    public async Task UpdateAsync()
    {
        _context.SaveChanges();
    }

    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}