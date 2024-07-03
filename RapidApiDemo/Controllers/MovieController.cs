using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RapidApiDemo.Models;

namespace RapidApiDemo.Controllers
{
    public class MovieController : Controller
    {
        public async Task<IActionResult> MovieList()
        {
           
            var client = new HttpClient();
            var request = new HttpRequestMessage
            {
                Method = HttpMethod.Get,
                RequestUri = new Uri("https://imdb-top-100-movies.p.rapidapi.com/"),
                Headers =
    {
        { "x-rapidapi-key", "37e86f89b6msh700db9c70e89110p13324ajsn5b53590ff364" },
        { "x-rapidapi-host", "imdb-top-100-movies.p.rapidapi.com" },
    },
            };
            using (var response = await client.SendAsync(request))
            {
                response.EnsureSuccessStatusCode();
                var body = await response.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<MovieViewModel>>(body);

                return View(values);
            }

          
        }
    }
}
