namespace PermissionPaladin.Infrastructure.Shared.HttpResults;

/// <summary>
/// Class representing HTTP results with a default payload of type 'object'
/// </summary>
public class Result : ResultBase<object>
{
    private Result(ResultStatus status, string? message = default, object? payload = default)
    {
        Message = message;
        Status = status;
        Payload = payload;
    }

    /// <summary>
    /// Creates an HTTP result with a status of 'Error'
    /// </summary>
    public static Result NotOk(string? errorMsg = default, object? payload = default)
        => new(ResultStatus.Error, errorMsg, payload);

    /// <summary>
    /// Creates an HTTP result with a status of 'Ok'
    /// </summary>
    public static Result Ok(object? payload = default, string? message = default)
        => new(ResultStatus.Ok, message, payload);
}
