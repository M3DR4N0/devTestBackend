using devTestBackend.Entities.Requests.Announcements;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace devTestBackend.Providers
{
    public class AnnouncementProvider 
    {
        public static async Task<IEnumerable<InsertAnnouncementRequest>> GetAllAsync()   
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri("https://www.bitmex.com"),
            };
   
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("/api/v1/announcement").ConfigureAwait(false);

            return await response.Content.ReadFromJsonAsync<IEnumerable<InsertAnnouncementRequest>>().ConfigureAwait(false);
        }   
    }
}
