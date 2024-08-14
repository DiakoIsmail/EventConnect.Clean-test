using EventConnect.Application.Contracts.Persistance;
using EventConnect.Domain.Models.Identity;
using EventConnect.Persistence.DatabaseContext;

namespace EventConnect.Persistence.Repositoryies;

public class UserRepository:GenericRepository<User>,IUserRepository
{
    public UserRepository(EcDatabaseContext context) : base(context)
    {
    }
    

}