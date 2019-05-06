using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{

  
    public class ServerResponseListMovie
    {
        public int page { get; set; }
        public int total_results { get; set; }
        public int total_pages { get; set; }
        public List<Movie> results { get; set; }
    }

    public class Movie
    {
        public int vote_count { get; set; }
        public int id { get; set; }
        public bool video { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public float popularity { get; set; }

        private Uri _poster_path;

        public string poster_path { get
            { return _poster_path.ToString(); }
            set { _poster_path = new Uri(Constants.posterBase + value); }
        }

        public string original_language { get; set; }
        public string original_title { get; set; }
        public List<int> genre_ids { get; set; }
        public string backdrop_path { get; set; }
        public bool adult { get; set; }
        public string overview { get; set; }
        public DateTime release_date { get; set; }
    }



}
