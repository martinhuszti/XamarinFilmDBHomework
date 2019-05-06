using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{


    public class ServerResponseListSeries
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Series> results { get; set; }
    }

    public class Series
    {
        [JsonProperty("original_name")]
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }

        [JsonProperty("name")]
        public string title { get; set; }
        public float popularity { get; set; }
        public string[] origin_country { get; set; }
        public int vote_count { get; set; }
        [JsonProperty("first_air_date")]

        public DateTime release_date { get; set; }
        public string backdrop_path { get; set; }
        public string original_language { get; set; }
        public int id { get; set; }
        public float vote_average { get; set; }
        public string overview { get; set; }
        private Uri _poster_path;

        public string poster_path { get { return _poster_path.ToString(); } set { _poster_path = new Uri(Constants.posterBase + value); } }
    }


}
