using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using UsersApi.Core.Entity;

namespace UsersApi.Infrastructure.Data;

public class UsersApiDbContext : DbContext
{
    public UsersApiDbContext(DbContextOptions<UsersApiDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; } = null!;

    public DbSet<UserSession> UserSession { get; set; } = null!;

    public DbSet<UserType> UserTypes { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(builder =>
        {
            builder.Property(b => b.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(_ => _.CreatedDate).Metadata
                .SetAfterSaveBehavior(PropertySaveBehavior.Ignore);

        });

        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();

        modelBuilder.Entity<UserType>()
            .HasData(new UserType {Id = 1, Name = "User"}, new UserType {Id = 2, Name = "Admin"});
    }
}