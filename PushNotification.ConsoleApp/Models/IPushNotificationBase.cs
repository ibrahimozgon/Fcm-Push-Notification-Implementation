namespace PushNotification.ConsoleApp.Models
{
    public interface IPushNotificationBase
    {
        IPushNotificationMessageBase Message { get; set; }
        string Token { get; set; }
    }
}