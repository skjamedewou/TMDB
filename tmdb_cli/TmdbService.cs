using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tmdb_cli
{
    internal class TmdbService
    {
        private readonly HttpClient _httpClient;

        public TmdbService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> getData(string name, string apiKey)
        {
            // _httpClient.DefaultRequestHeaders.UserAgent.ParseAdd("tmdb-cli");
            string url = "";
            switch (name)
            {
                case "playing":
                    url = "now_playing";
                    break;
                case "popular":
                    url = "popular";
                    break;
                case "top":
                    url = "top_rated";
                    break;
                case "upcoming":
                    url = "upcoming";
                    break;
                default:
                    break;
            }
            HttpResponseMessage response = await _httpClient.GetAsync($"https://api.themoviedb.org/3/movie/{url}?api_key={apiKey}");

            string rep = await response.Content.ReadAsStringAsync();

            return rep;

        }
    }
}
