using FirebaseAdmin.Messaging;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirebasePushNotification.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PushNotification : ControllerBase
    {
        [Route("SendPushNotification")]
        [HttpPost]
        public async Task<IActionResult> SendPushNotification(PushMessagePayload? request)
        {
            // device id o ABU Rayhan vivo v20 ### 317dd17953b9a5cb ###

            request = new PushMessagePayload("Push Notify", "Test Push Notification", "cOOJeXG8TXGOz8yDthX2xx:APA91bEO1QtvqDjm5IYbKKR2r-BVCiWSz6J8ncN4ldMLe4ELF18WfelBCFnvN2v9b_yLBzwFF-GSVSRqasmAmhaDHJwAuYUyt0XA1e2_o3KUMvJ0g_pehabnjYQKgHgaMYMuu1m73mND");

            var message = new Message()
            {
                Notification = new Notification
                {
                    Title = request.Title,
                    Body = request.Body,
                },
                Token = request.DeviceToken
            };

            var messaging = FirebaseMessaging.DefaultInstance;
            var result = await messaging.SendAsync(message);

            if (!string.IsNullOrEmpty(result))
            {
                return Ok(new PushMessageResponseDto { IsSuccess = true, Message = "Message sent successfully!" });
            }
            else
            {
                return BadRequest(new PushMessageResponseDto { IsSuccess = true, Message = "Error sending the message." });
            }
        }
    }
}
