namespace KbsMobile.Core.DTOs;

public class ApiResponse<T>
{
    public bool IsSuccess { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }
    public IEnumerable<string> Errors { get; set; } = Array.Empty<string>();

    public static ApiResponse<T> Success(T data, string? message = null) => new() { IsSuccess = true, Data = data, Message = message };
    public static ApiResponse<T> Fail(string message, params string[] errors) => new() { IsSuccess = false, Message = message, Errors = errors };
}
