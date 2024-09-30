namespace FirebasePushNotification
{
    public record PushMessagePayload(string Title, string Body, string DeviceToken, Dictionary<string, string>? Data = null);
}
