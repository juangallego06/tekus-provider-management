using FluentValidation.Results;

namespace Tekus.Application.Common;

public class Response<T>
{
    public T? Data { get; set; }

    public bool IsSuccess { get; set; }

    public string Message { get; set; } = string.Empty;

    public IEnumerable<ValidationFailure>? Errors { get; set; }
}