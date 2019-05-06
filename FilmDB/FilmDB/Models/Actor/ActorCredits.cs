using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{
    public class ActorCredits
    {
        public List<ActorCast> cast { get; set; }
        public List<Crew> crew { get; set; }
        public int id { get; set; }
    }

    public class ActorCast
    {
        public string character { get; set; }
        public string credit_id { get; set; }
        public string release_date { get; set; }
        public int vote_count { get; set; }
        public bool video { get; set; }
        public bool adult { get; set; }
        public float vote_average { get; set; }
        public string title { get; set; }
        public List<int> genre_ids { get; set; }
        public string original_language { get; set; }
        public string original_title { get; set; }
        public float popularity { get; set; }
        public int id { get; set; }
        public string backdrop_path { get; set; }
        public string overview { get; set; }

        private Uri _poster_path;

        public string poster_path
        {
            get { return _poster_path.ToString(); }
            set { _poster_path = new Uri(Constants.posterBase + value); }
        }

    }

}
