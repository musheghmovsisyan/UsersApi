namespace UsersApi.Core.Models.ModelsView;

public class ErrorResponse
{
    public ErrorResponse()
    {
    }

    public ErrorResponse(ErrorModel error)
    {
        Errors.Add(error);
    }

    public bool Success { get; set; } = false;

    public List<ErrorModel> Errors { get; set; } = new();
}