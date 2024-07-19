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
    public class ApiResim
    {
        static string apiUrl = "http://192.168.1.251/";

        public static async Task<List<EntityResim>> GetResimler()
        {
            List<EntityResim> resimler = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                HttpResponseMessage response = await client.GetAsync("liste");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    resimler = JsonConvert.DeserializeObject<List<EntityResim>>(jsonString);
                }
            }
            return resimler;
        }

        public static async Task<List<EntityResim>> GetResimlerByKullaniciID(int kullaniciID)
        {
            List<EntityResim> resimler = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                HttpResponseMessage response = await client.GetAsync($"kullanici?kullaniciID={kullaniciID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    resimler = JsonConvert.DeserializeObject<List<EntityResim>>(jsonString);
                }
            }
            return resimler;
        }

        public static async Task<EntityResim> GetVarsayilanResim(int kullaniciID)
        {
            EntityResim varsayilanResim = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                HttpResponseMessage response = await client.GetAsync($"varsayilan/{kullaniciID}");
                if (response.IsSuccessStatusCode)
                {
                    var jsonString = await response.Content.ReadAsStringAsync();
                    varsayilanResim = JsonConvert.DeserializeObject<EntityResim>(jsonString);
                }
            }
            return varsayilanResim;
        }

        public static async Task<bool> EkleResim(List<EntityResim> resim)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                var jsonContent = JsonConvert.SerializeObject(resim);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("ekle/", content);
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> DuzenleResim(EntityResim resim)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var jsonContent = JsonConvert.SerializeObject(resim);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                HttpResponseMessage response = await client.PutAsync($"duzenle/{resim.ID}", content);
                return response.IsSuccessStatusCode;
            }
        }

        public static async Task<bool> SilResim(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token.DBToken.GetToken());

                HttpResponseMessage response = await client.DeleteAsync($"sil/{id}");
                return response.IsSuccessStatusCode;
            }
        }
    }
}
