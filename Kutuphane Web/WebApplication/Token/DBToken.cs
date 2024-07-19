using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace WebApplication.Token
{
    public class DBToken
    {
        static string apiUsername = "1";
        static string apiPassword = "1";
        static EntityToken apiToken = null;
        static DateTime apiTokenDate = DateTime.Now;
        static string apiUrl = "http://192.168.1.251/";

        public static string GetToken()
        {

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(apiUrl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var content = new FormUrlEncodedContent(new[]
                    {
                            new KeyValuePair<string, string>("grant_type", "password"),
                            new KeyValuePair<string, string>("username", apiUsername),
                            new KeyValuePair<string, string>("password",apiPassword)
                        });
                    var response = client.PostAsync(apiUrl + "token", content).Result;
                    var result = JsonConvert.DeserializeObject<EntityToken>(response.Content.ReadAsStringAsync().Result);
                    apiToken = result;
                }

            }
            catch (Exception ex)
            {

            }

            return apiToken.access_token;
        }

    }
}