using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{

    public class Actor
    {
        public DateTime birthday { get; set; }
        public string known_for_department { get; set; }
        public object deathday { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string[] also_known_as { get; set; }
        public int gender { get; set; }
        public string biography { get; set; }
        public float popularity { get; set; }
        public string place_of_birth { get; set; }

        private Uri _profile_path;

        public string profile_path
        {
            get { return _profile_path.ToString(); }
            set { _profile_path = new Uri(Constants.posterBase + value); }
        }

        public bool adult { get; set; }
        public string imdb_id { get; set; }
        public object homepage { get; set; }
    }



}
