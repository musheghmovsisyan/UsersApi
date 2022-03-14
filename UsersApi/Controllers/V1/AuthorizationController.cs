using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using UsersApi.Common;
using UsersApi.Core.Contracts.Services;
using UsersApi.Core.Models.V1.Requests;
using UsersApi.Core.Models.V1.Responses;

namespace UsersApi.Controllers.V1;

public class AuthorizationController : Controller
{
    private readonly IAuthorizationService _authorizationService;
    private readonly JsonSerializerSettings _jsSettings;

    public AuthorizationController(JsonSerializerSettings jsSettings, IAuthorizationService authorizationService)
    {
        _jsSettings = jsSettings;
        _authorizationService = authorizationService;
    }

    [HttpPost(ApiRoutes.AuthorizationApi.Login)]
    public async Task<IActionResult> Login([FromBody] UserLoginRequest request)
    {
        var authResponse = await _authorizationService.LoginAsync(request.Username, request.Password);

        if (!authResponse.Success)
        {
            return new JsonResult(new AuthFailedResponse
            {
                Errors = authResponse.Errors
            }, _jsSettings) {StatusCode = 400};
        }

        return new JsonResult(new AuthSuccessResponse
        {
            Success = true
        }, _jsSettings);
    }
}