using EventConnectIdentity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EventConnectIdentity.DbContext;

public class EventConnectIdentityDbContext: IdentityDbContext<ApplicationUser>
{
    public EventConnectIdentityDbContext(DbContextOptions<EventConnectIdentityDbContext> options) : base(options){ }
 
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(EventConnectIdentityDbContext).Assembly);
        
    }

}