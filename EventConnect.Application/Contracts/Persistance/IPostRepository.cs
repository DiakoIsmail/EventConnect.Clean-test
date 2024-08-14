using EventConnect.Domain.Entitys.Posts;

namespace EventConnect.Application.Contracts.Persistance;
// repository that enhearets from IGenericRepository withe Post class as a generic type
public interface IPostRepository: IGenericRepository<Post>
{
    Task<bool> PostExists(string userID, int postId);
    Task<List<Post>> GetPostsByUserId(string userId);
    Task<List<Post>> GetPosts();


    Task UpdateAsync();
    Task SaveChangesAsync();
}