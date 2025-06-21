namespace Utils;
public class OperationResult<T>
{
    public bool Success { get; set; }
    public string? Message { get; set; }
    public T? Data { get; set; }

    public static OperationResult<T> Ok(string? message = null) =>
        new() { Success = true, Message = message };

    public static OperationResult<T> Fail(string message) =>
        new() { Success = false, Message = message };
}