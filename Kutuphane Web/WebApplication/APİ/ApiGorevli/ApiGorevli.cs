using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication
{
    public class ApiGorevli
    {
        static string apiUrl = "http://192.168.1.251/";

        public static async Task<string> LoginAsync(Gorevli gorevli)
        {
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                var json = JsonConvert.SerializeObject(gorevli);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl + "api/login", content);

            
                if (response.IsSuccessStatusCode)
                {
                    return "Giriş başarılı.";
                }
                else if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    return "Kullanıcı adı veya şifre boş olamaz.";
                }
                else if (response.StatusCode == HttpStatusCode.NotFound)
                {
                    return "Kullanıcı bulunamadı.";
                }
                else if (response.StatusCode == HttpStatusCode.Unauthorized)
                {
                    return "Yanlış şifre.";
                }
                else
                {
                    return "Bilinmeyen bir hata oluştu.";
                }
            }
        }
    }
}
