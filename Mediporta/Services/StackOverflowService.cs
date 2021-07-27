using Mediporta.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;

namespace Mediporta.Services
{
    public class StackOverflowService : IStackOverflowService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public StackOverflowService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<List<Tag>> GetMostPopularTagsAsync(int toLoad)
        {
            List<Tag> Tags = new List<Tag>();
 
            int actualyPage = 1;
            bool isLoaded = false;
 
            System.Collections.Specialized.NameValueCollection queryParams = HttpUtility.ParseQueryString(string.Empty);
            queryParams["order"] = "desc";
            queryParams["sort"] = "popular";
            queryParams["site"] = "stackoverflow";
 
            using (HttpClient client = _httpClientFactory.CreateClient("stackOverflowTags"))
            {
                while (!isLoaded)
                {
                    queryParams["pagesize"] = toLoad > 100
                        ? "100"
                        : toLoad.ToString();
                    queryParams["page"] = actualyPage.ToString();

                    HttpResponseMessage response = await client.GetAsync($"?{queryParams}");
                    string responseBody = await response.Content.ReadAsStringAsync();
                    response.EnsureSuccessStatusCode();
 
                    TagCollection tag = JsonSerializer.Deserialize<TagCollection>(responseBody);
                    Tags.AddRange(tag.Items);
 
                    if (toLoad < 100 | !tag.HasMore)
                    {
                        isLoaded = true;
                    }
 
                    toLoad -= 100;
                    actualyPage++;
                }
            }
            return Tags;
        }

    }
}
