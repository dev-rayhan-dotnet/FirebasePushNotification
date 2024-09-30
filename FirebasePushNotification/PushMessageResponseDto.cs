using Newtonsoft.Json;

namespace FirebasePushNotification
{
    public class PushMessageResponseDto
    {
        [JsonProperty("isSuccess")] public bool IsSuccess { get; set; }

        [JsonProperty("message")] public string Message { get; set; }
    }
}
