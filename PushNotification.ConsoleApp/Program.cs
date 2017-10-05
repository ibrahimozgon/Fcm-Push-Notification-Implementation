using System;
using System.Linq;
using PushNotification.ConsoleApp.Models;

namespace PushNotification.ConsoleApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //https://stackoverflow.com/questions/37427709/firebase-messaging-where-to-get-server-key
            //https://console.firebase.google.com/project/--projectName---/settings/cloudmessaging/
            const string authToken =
                "your_fcm_authentication_token";

            var userToken = "user_token";

            var api = new FcmApi();

            var pushNotification = new FcmWebPushNotification
            {
                Message = new FcmWebNotificationMessage
                {
                    Type = NotificationType.Type1.ToString(),
                    Icon = "https://foto.arabam.com/assets/dist/img/notifications/192x192-arabam-ikon.png",
                    Badge = "https://foto.arabam.com/assets/dist/img/notifications/a-monochrome.png",
                    ImageUrl = "https://arbimg55.mncdn.com/ilanfotograflari/2017/10/03/7666880/6c98e628-10ce-4482-8f1c-e0e3491d6696_image_for_silan_7666880_1920x1080.jpg",
                    Title = "Yeni İlan Var!",
                    Body = "Aramanız için yeni ilan girildi. Hemen inceleyin, hayalinizdeki arabaya kavuşun!",
                    ClickAction ="https://www.arabam.com"
                },
                Token = userToken
            };
            var result = api.Push(authToken, pushNotification);
            if (result.Success)
                return;
            if (result.Results == null || !result.Results.Any())
                return;
            var error = result.Results.Select(t => t.Error).Aggregate((current, next) => current + "|" + next);
            Console.WriteLine(error);
        }
    }
}
