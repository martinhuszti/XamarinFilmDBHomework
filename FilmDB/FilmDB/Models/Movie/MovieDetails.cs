using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{
    public class MovieDetails
    {
        public bool adult { get; set; }
        public string backdrop_path { get; set; }
        public object belongs_to_collection { get; set; }
        public int budget { get; set; }
        public List<Genre> genres { get; set; }
        public object homepage { get; set; }
        public int id { get; set; }
        public string imdb_id { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public string overview { get; set; }
        public float popularity { get; set; }

        private Uri _poster_path;

        public string poster_path
        {
            get { return _poster_path.ToString(); }
            set { _poster_path = new Uri(Constants.posterBase + value); }
        }

        public Production_Companies[] production_companies { get; set; }
        public Production_Countries[] production_countries { get; set; }
        public DateTime release_date { get; set; }
        public int revenue { get; set; }
        public int runtime { get; set; }
        public Spoken_Languages[] spoken_languages { get; set; }
        public string status { get; set; }
        public string tagline { get; set; }
        public string title { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
    }



    public class Production_Companies
    {
        public int id { get; set; }
        public object logo_path { get; set; }
        public string name { get; set; }
        public string origin_country { get; set; }
    }

    public class Production_Countries
    {
        public string iso_3166_1 { get; set; }
        public string name { get; set; }
    }

    public class Spoken_Languages
    {
        public string iso_639_1 { get; set; }
        public string name { get; set; }
    }
}
