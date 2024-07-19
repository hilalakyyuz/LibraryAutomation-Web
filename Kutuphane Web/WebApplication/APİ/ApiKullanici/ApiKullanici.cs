using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebApplication
{
    public class ApiKullanici
    {
        static string apiUrl = "http://192.168.1.251/";
        public static List<Kullanici> KullaniciListe()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + "api/kullanicilar/GetKullanicilar2").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var _liste = JsonConvert.DeserializeObject<List<Kullanici>>(json);
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

        public static Kullanici KullaniciGetir(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + $"api/kullanicilar/GetKullanici2?id={id}").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var kullanici = JsonConvert.DeserializeObject<Kullanici>(json);
                        return kullanici;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }

        public static async Task<bool> KullaniciEkle(Kullanici kullanici)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl + "api/kullanicilar/PostKullanici", content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public static async Task<bool> KullaniciDuzenle(int id, Kullanici kullanici)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl + "api/kullanicilar/PutKullanici/" + id, content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
        }


        public static async Task<bool> KullaniciSil(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = await client.GetAsync(apiUrl + $"api/kullanicilar/GetKullaniciSil?id={id}");

                    if (response.IsSuccessStatusCode)
                    {
                        return true;
                    }
                    else
                    {
                       
                        var errorMessage = await response.Content.ReadAsStringAsync();
                        Console.WriteLine("API Hatası: " + errorMessage);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}