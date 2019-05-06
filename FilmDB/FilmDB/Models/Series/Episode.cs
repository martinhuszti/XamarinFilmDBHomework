using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{


    public class EpisodeListResponse
    {
        public string _id { get; set; }
        public string air_date { get; set; }
        public List<Episode> episodes { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int id { get; set; }
        public string poster_path { get; set; }
        public int season_number { get; set; }
    }

    public class Episode
    {
        public DateTime air_date { get; set; }
        public int episode_number { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string overview { get; set; }
        public int season_number { get; set; }
        public int show_id { get; set; }

        private Uri _still_path;

        public string still_path
        {
            get { return _still_path.ToString(); }
            set
            {
                _still_path = new Uri(Constants.posterBase + value);
            }
        }
        public float vote_average { get; set; }
        public int vote_count { get; set; }
      
    }

    public class Guest_Stars
    {
        public int id { get; set; }
        public string name { get; set; }
        public string credit_id { get; set; }
        public string character { get; set; }
        public int order { get; set; }
        public int gender { get; set; }
        public string profile_path { get; set; }
    }


}

