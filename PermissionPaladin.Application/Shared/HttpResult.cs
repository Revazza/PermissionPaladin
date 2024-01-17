namespace PermissionPaladin.Application.Shared;

public enum HttpResultStatus
{
    Ok = 1,
    Error = 0,
}

public class HttpResultBase<T>
{
    public HttpResultStatus Status { get; set; } = HttpResultStatus.Ok;
    public string? Message { get; set; } = string.Empty;
    public T? Payload { get; set; }
}

public class HttpResult : HttpResultBase<object>
{

    private HttpResult(HttpResultStatus status, string? message = default, object? payload = default)
    {
        Message = message;
        Status = status;
        Payload = payload;
    }

    public static HttpResult NotOk(string? errorMsg = default, object? payload = default)
        => new(HttpResultStatus.Error, errorMsg, payload);

    public static HttpResult Ok(object? payload = default, string? message = default)
        => new(HttpResultStatus.Ok, message, payload);

}


