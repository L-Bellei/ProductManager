namespace ProductManager.Domain.Notifier;

public class Notification(string message, int statusCode)
{
    public string Message { get; set; } = message;
    public int StatusCode { get; set; } = statusCode;
}
