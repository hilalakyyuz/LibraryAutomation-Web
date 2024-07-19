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
    public class ApiOdunc
    {
        static string apiUrl = "http://192.168.1.251/";
        public static List<Odunc> OduncListe()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {

                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + "api/odunc/getoduncler").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var _liste = JsonConvert.DeserializeObject<List<Odunc>>(json);
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
        public static Odunc OduncGetir(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + $"api/odunc/GetOdunc?id={id}").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var yazar = JsonConvert.DeserializeObject<Odunc>(json);
                        return yazar;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        public static Odunc OduncGetir2(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = client.GetAsync(apiUrl + $"api/odunc/GetOdunc2?id={id}").Result;
                    var json = response.Content.ReadAsStringAsync().Result;

                    if (response.IsSuccessStatusCode)
                    {
                        var yazar = JsonConvert.DeserializeObject<Odunc>(json);
                        return yazar;
                    }
                }
            }
            catch (Exception ex)
            {

            }

            return null;
        }
        public static async Task<bool> OduncEkle(Odunc odunc)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(odunc);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl + "api/odunc/PostOdunc", content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }


        public static async Task<bool> OduncDuzenle(int id, Odunc oduncK)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(oduncK);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PutAsync(apiUrl + "api/odunc/PutOdunc/" + id, content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }

        public static async Task<bool> OduncSil(int id)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = await client.GetAsync(apiUrl + $"api/odunc/GetOduncSil?id={id}");

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

        public static async Task<bool> OduncKaydet(List<Odunc> oduncListesi)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var json = JsonConvert.SerializeObject(oduncListesi);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    var response = await client.PostAsync(apiUrl + "api/odunc/PostKaydet", content);

                    return response.IsSuccessStatusCode;
                }
            }
            catch (Exception ex)
            {

                return false;
            }
        }
        public static async Task<List<Odunc>> RaporListeAsync(int kullaniciid)
        {
            List<Odunc> liste = new List<Odunc>();
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                    var response = await client.GetAsync(apiUrl + $"api/odunc/raporliste/{kullaniciid}");
                    var json = await response.Content.ReadAsStringAsync();

                    if (response.IsSuccessStatusCode)
                    {
                        var oduncKitaplar = JsonConvert.DeserializeObject<List<Odunc>>(json);
                        liste = oduncKitaplar;
                    }
                    return liste;

                }
            }
            catch (Exception ex)
            {

            }
            return liste;

        }

    }
}
