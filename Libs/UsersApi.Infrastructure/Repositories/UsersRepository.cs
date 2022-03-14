using Microsoft.EntityFrameworkCore;
using UsersApi.Core.Contracts.Repositories;
using UsersApi.Core.Entity;
using UsersApi.Core.Extension;
using UsersApi.Infrastructure.Data;

namespace UsersApi.Infrastructure.Repositories;

public class UsersRepository : BaseRepository<User, string>, IUsersRepository
{
    public UsersRepository(UsersApiDbContext dbContext) : base(dbContext)
    {
    }

    public override async Task<User?> GetByIdAsync(string id)
    {
        return await DbContext.Users.Include(_ => _.UserType).FirstOrDefaultAsync(_ => _.Id == id);
    }

    public Task<List<User>> GetUsersAsync(int? pageNumber, int? userTypeId, DateTime? createdDate,
        bool? onlySessionsMoreTwo)
    {
        var users = DbContext.Users.Include(_ => _.UserType).AsQueryable();

        if (userTypeId is > 0)
        {
            users = users.Where(_ => _.UserTypeId == userTypeId);
        }

        if (createdDate.HasValue && createdDate.Value > DateTime.MinValue)
        {
            var createdDateValue = createdDate.Value.Date;
            users = users.Where(_ =>
                _.CreatedDate > createdDateValue.AddDays(-1) && _.CreatedDate < createdDateValue.AddDays(1));
        }

        if (onlySessionsMoreTwo is true)
        {
            var userIds = DbContext.UserSession.GroupBy(_ => _.UserId).Where(_ => _.Count() > 2).Select(_ => _.Key);
            users = users.Where(_ => userIds.Contains(_.Id));
        }

        users = users.GetPage(pageNumber);

        return users.ToListAsync();
    }

    public Task<bool> IsExistAsync(User user)
    {
        return DbContext.Users.AnyAsync(_ => _.Email == user.Email && _.Id != user.Id);
    }

    public Task<bool> IsExistByIdAsync(string id)
    {
        return DbContext.Users.AnyAsync(_ => _.Id == id);
    }

    public Task<User?> FindUserByUserNameOrEmailAsync(string userNameOrEmail)
    {
        return DbContext.Users.FirstOrDefaultAsync(_ => _.Email == userNameOrEmail || _.UserName == userNameOrEmail);
    }
}