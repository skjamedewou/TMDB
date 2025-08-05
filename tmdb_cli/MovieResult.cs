using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace tmdb_cli
{
    internal class MovieResponse
    {
        [JsonPropertyName("results")]
        public List<MovieResult> Responses { get; set; }
    }
    internal class MovieResult
    {
        public bool adult {  get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public double popularity { get; set; }
        public string release_date { get; set; }
        public string title {  get; set; }
        public double vote_average {  get; set; }
        public double vote_count {  get; set; }

    }
}
