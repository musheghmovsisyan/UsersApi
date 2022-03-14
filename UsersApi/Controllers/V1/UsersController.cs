using System.ComponentModel.DataAnnotations;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using UsersApi.Common;
using UsersApi.Core.Contracts.Services;
using UsersApi.Core.Entity;
using UsersApi.Core.Models.V1.Requests;
using UsersApi.Core.Models.V1.Responses;

namespace UsersApi.Controllers.V1;

public class UsersController : Controller
{
    private readonly IUsersService _usersService;
    private readonly IMapper _mapper;

    public UsersController(IUsersService usersService, IMapper mapper)
    {
        _usersService = usersService;
        _mapper = mapper;
    }

    [HttpGet(ApiRoutes.UserApi.Get)]
    public async Task<UserResponse> GetUserById([FromQuery] [Required] string id)
    {
        var result = await _usersService.GetByIdAsync(id);
        return _mapper.Map<UserResponse>(result);
    }

    [HttpPost(ApiRoutes.UserApi.Add)]
    public async Task<UserResponse> Add([FromBody] UserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        user.NormalizedEmail = request.Email.ToUpperInvariant();
        user.NormalizedUserName = request.UserName.ToUpperInvariant();
        user.ModifiedDate= DateTime.UtcNow;

        var result = await _usersService.AddAsync(user);

        return _mapper.Map<UserResponse>(result);
    }

    [HttpPut(ApiRoutes.UserApi.Update)]
    public async Task<IActionResult> Update([FromQuery] [Required] string id, [FromBody] UserRequest request)
    {
        var user = _mapper.Map<User>(request);
        user.Id = id;
        user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
        user.NormalizedEmail = request.Email.ToUpperInvariant();
        user.NormalizedUserName = request.UserName.ToUpperInvariant();
        user.ModifiedDate = DateTime.UtcNow;
        await _usersService.UpdateAsync(user);

        return Ok("Success");
    }

    [HttpDelete(ApiRoutes.UserApi.Delete)]
    public async Task<IActionResult> Delete([FromQuery] [Required] string id)
    {
        await _usersService.DeleteAsync(id);

        return Ok("Success");
    }

    [HttpGet(ApiRoutes.UserApi.GetUsers)]
    public async Task<UsersResponse> GetUsers([FromQuery] int? pageNumber, [FromQuery] int? userTypeId,
        [FromQuery] DateTime? createdDate, [FromQuery] bool? onlySessionsMoreTwo)
    {
        var users = await _usersService.GetUsers(pageNumber, userTypeId, createdDate, onlySessionsMoreTwo);

        return new UsersResponse {Users = _mapper.Map<IList<UserResponse>>(users)};
    }
}