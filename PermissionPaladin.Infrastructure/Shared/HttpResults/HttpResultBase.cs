﻿namespace PermissionPaladin.Infrastructure.Shared.HttpResults;

/// <summary>
/// Base class for HTTP results with generic payload
/// </summary>
public class HttpResultBase<T>
{
    public HttpResultStatus Status { get; set; } = HttpResultStatus.Ok;
    public string? Message { get; set; } = string.Empty;
    public T? Payload { get; set; }
}
