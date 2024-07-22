namespace Jobify.Api.Models.Common;

public class ResultStatus
{
    public ResultStatus(int statusCode, string? message = null)
    {
        StatusCode = statusCode;
        Message = message;
    }

    public string? Message { get; set; }

    /// <summary>
    /// <see cref="StatusCodes"/>
    /// </summary>
    public int StatusCode { get; set; }

    public bool Success =>
        StatusCode is StatusCodes.Status200OK or
            StatusCodes.Status201Created or
            StatusCodes.Status202Accepted or
            StatusCodes.Status204NoContent;
}

public class ResultStatus<T> : ResultStatus
{
    public ResultStatus(int statusCode, string? message = null)
        : base(statusCode, message)
    { }

    public ResultStatus(int statusCode, T result) : base(statusCode)
    {
        Result = result;
    }

    public T? Result { get; set; }
}