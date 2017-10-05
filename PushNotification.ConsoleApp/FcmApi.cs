using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using PushNotification.ConsoleApp.Models;

namespace PushNotification.ConsoleApp
{
    public class FcmApi
    {
        private const string Url = "https://fcm.googleapis.com/fcm/send";

        public FcmResponse Push(string authToken, IFcmPushNotificationBase pushNotification)
        {
            try
            {
                var httpRequest = (HttpWebRequest)WebRequest.Create(Url);
                httpRequest.Method = WebRequestMethods.Http.Post;
                httpRequest.Headers.Add("Authorization:key=" + authToken);
                var postDataJson = SerializeObject(pushNotification);
                var data = Encoding.UTF8.GetBytes(postDataJson);
                httpRequest.ContentType = "application/json; charset=utf-8";
                httpRequest.ContentLength = data.Length;

                using (var stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }

                using (var response = (HttpWebResponse)httpRequest.GetResponse())
                using (var stream = response.GetResponseStream())
                {
                    if (stream != null)
                    {
                        var json = new StreamReader(stream).ReadToEnd();
                        return JsonConvert.DeserializeObject<FcmResponse>(json);
                    }
                }
                return new FcmResponse
                {
                    SuccessCount = 0
                };
            }
            catch (WebException ex)
            {
                try
                {
                    if (ex.Response != null)
                        using (var stream = ex.Response.GetResponseStream())
                        {
                            if (stream != null)
                            {
                                using (var reader = new StreamReader(stream))
                                {
                                    var response = reader.ReadToEnd();
                                    return JsonConvert.DeserializeObject<FcmResponse>(response);
                                }
                            }
                        }
                }
                catch (Exception e)
                {
                    Console.WriteLine(string.Format("Fcm Api {0}", e));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return new FcmResponse
            {
                SuccessCount = 0,
                Results = new List<FcmResult>
                {
                    new FcmResult
                    {
                        MessageId = "500 Error"
                    }
                }
            };
        }

        private static string SerializeObject(IFcmPushNotificationBase pushNotification)
        {
            return JsonConvert.SerializeObject(pushNotification, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}