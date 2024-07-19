using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication
{
    public class ApiKitap
    {
        static string apiUrl = "http://192.168.1.251/";
        public static List<Kitap> KitapListe()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + "api/kitaplar/GetKitaplar").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var _liste = JsonConvert.DeserializeObject<List<Kitap>>(json);
                        return _liste;
                    }
                    else
                    {
                        //DB_SPHataAyiklama.ListeyeEkleMesajGoster(response, mesaj, "CategoryID:" + categoryid, "HB", "GetCategoryAttribute");
                    }
                }
            }
            catch (Exception ex)
            {
                //DB_SPHataAyiklama.ListeyeEkleMesajGoster(ex, mesaj, "CategoryID:" + categoryid, "HB", "GetCategoryAttribute");
            }

            return null;
        }
        public static Kitap KitapGetir(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + $"api/kitaplar/GetKitap?id={id}").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var yazar = JsonConvert.DeserializeObject<Kitap>(json);
                        return yazar;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public static async Task<bool> KitapEkle(Kitap kitap)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(kitap);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl + "api/kitaplar/PostKitap", content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static async Task<bool> KitapDuzenle(int id, Kitap kitap)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(kitap);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl + "api/kitaplar/PutKitap/" + id, content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static async Task<bool> KitapSil(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = await client.GetAsync(apiUrl + $"api/kitaplar/GetKitapSil?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                       
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        if (errorMessage.Contains("Bu kitap ödünç alınmış durumda olduğu için silinemez."))
                        {
                            throw new Exception(errorMessage);

                           // Console.WriteLine(errorMessage);
                        }
                        else
                        {
                            throw new Exception("API Hatası: " + errorMessage);
                           
                        }
                        return false;

                    }
                }
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }
    }
}