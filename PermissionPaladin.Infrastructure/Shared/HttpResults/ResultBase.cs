namespace PermissionPaladin.Infrastructure.Shared.HttpResults;

/// <summary>
/// Base class for HTTP results with generic payload
/// </summary>
public class ResultBase<T>
{
    public ResultStatus Status { get; set; } = ResultStatus.Ok;
    public string? Message { get; set; } = string.Empty;
    public T? Payload { get; set; }
}
