using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{

    public class SeriesDetail
    {
        public string backdrop_path { get; set; }
        public List<Created_By> created_by { get; set; }
        public List<int> episode_run_time { get; set; }
        public DateTime first_air_date { get; set; }
        public List<Genre> genres { get; set; }
        public string homepage { get; set; }
        public int id { get; set; }
        public bool in_production { get; set; }
        public List<string> languages { get; set; }
        public DateTime last_air_date { get; set; }


        [JsonProperty("name")]
        public string title { get; set; }

        public List<Network> networks { get; set; }
        public int number_of_episodes { get; set; }
        public int number_of_seasons { get; set; }
        public List<string> origin_country { get; set; }
        public string original_language { get; set; }

        [JsonProperty("original_name")]
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }

        private Uri _poster_path;

        public string poster_path
        {
            get { return _poster_path.ToString(); }
            set { _poster_path = new Uri(Constants.posterBase + value); }
        }
        public List<Production_Companies> production_companies { get; set; }
        public List<Season> seasons { get; set; }
        public string status { get; set; }
        public string type { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
        public Episode last_episode_to_air { get; set; }
        public Episode next_episode_to_air { get; set; }


    }

  

    public class Created_By
    {
        public int id { get; set; }
        public string credit_id { get; set; }
        public string name { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }


    public class Network
    {
        public string name { get; set; }
        public int id { get; set; }
        public string logo_path { get; set; }
        public string origin_country { get; set; }
    }



    public class Season
    {
        public string air_date { get; set; }
        public int episode_count { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }


}
