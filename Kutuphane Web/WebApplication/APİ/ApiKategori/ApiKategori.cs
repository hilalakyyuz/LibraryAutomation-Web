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
    public class ApiKategori
    { 
            static string apiUrl = "http://192.168.1.251/";
             public static List<Kategori> KategoriListe()
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {

                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                        var response = client.GetAsync(apiUrl + "api/kategoriler/GetKategoriler").Result;
                        var json = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var _liste = JsonConvert.DeserializeObject<List<Kategori>>(json);
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
            public static Kategori KategoriGetir(int id)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                        var response = client.GetAsync(apiUrl + $"api/kategoriler/GetKategori?id={id}").Result;
                        var json = response.Content.ReadAsStringAsync().Result;

                        if (response.IsSuccessStatusCode)
                        {
                            var yazar = JsonConvert.DeserializeObject<Kategori>(json);
                            return yazar;
                        }
                    }
                }
                catch (Exception ex)
                {

                }

                return null;
            }
            public static async Task<bool> KategoriEkle(Kategori kategori)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                        var json = JsonConvert.SerializeObject(kategori);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PostAsync(apiUrl + "api/kategoriler/PostKategori", content);

                        return response.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }
            public static async Task<bool> KategoriDuzenle(int id, Kategori kategori)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                        var json = JsonConvert.SerializeObject(kategori);
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        var response = await client.PutAsync(apiUrl + "api/kategoriler/PutKategori/" + id, content);

                        return response.IsSuccessStatusCode;
                    }
                }
                catch (Exception ex)
                {

                    return false;
                }
            }

            public static async Task<bool> KategoriSil(int id)
            {
                try
                {
                    using (HttpClient client = new HttpClient())
                    {
                        client.DefaultRequestHeaders.Accept.Clear();
                        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                        client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                        var response = await client.GetAsync(apiUrl + $"api/kategoriler/GetKategoriSil?id={id}");

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

