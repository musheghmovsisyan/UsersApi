namespace UsersApi.Core.Models.V1.Responses;

public class AuthFailedResponse
{
    public bool Success { get; set; }

    public IEnumerable<string>? Errors { get; set; }
}