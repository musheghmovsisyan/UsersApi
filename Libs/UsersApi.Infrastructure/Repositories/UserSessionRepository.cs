using UsersApi.Core.Contracts.Repositories;
using UsersApi.Core.Entity;
using UsersApi.Infrastructure.Data;

namespace UsersApi.Infrastructure.Repositories;

public class UserSessionRepository : BaseRepository<UserSession, string>, IUserSessionRepository
{
    public UserSessionRepository(UsersApiDbContext dbContext) : base(dbContext)
    {
    }
}