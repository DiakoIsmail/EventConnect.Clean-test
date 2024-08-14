using EventConnect.Application.Contracts;
using EventConnect.Domain.Common;
using EventConnect.Domain.Entitys.Posts;
using EventConnect.Domain.Models.Identity;
using Microsoft.EntityFrameworkCore;

namespace EventConnect.Persistence.DatabaseContext;

public class EcDatabaseContext: DbContext
{
    private readonly IUserServices _userServices;



    public EcDatabaseContext(DbContextOptions<EcDatabaseContext> options,IUserServices userServices):base(options)
    {
      _userServices= userServices;           
    }
    
        
    public DbSet<Post> Posts { get; set; } 
    public DbSet<User> Users { get; set; } 

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EcDatabaseContext).Assembly);
        //modelBuilder.ApplyConfiguration(new LeaveTypeConfiguration());
        base.OnModelCreating(modelBuilder);
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                     .Where(q =>q.State == EntityState.Added || q.State == EntityState.Modified ))
        {
            entry.Entity.DateModified = DateTime.Now;
            entry.Entity.ModifiedBy = _userServices.UserId;
            if (entry.State == EntityState.Added)
            {
                entry.Entity.DateCreated = DateTime.Now;
                entry.Entity.CreatedBy = _userServices.UserId;
            }
        }
        return base.SaveChangesAsync(cancellationToken);
    }
}