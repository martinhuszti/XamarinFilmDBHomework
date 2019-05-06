using System;
using System.Collections.Generic;
using System.Text;

namespace FilmDB.Models
{

    public class Credits
    {
        public int id { get; set; }
        public List<Cast> cast { get; set; }
        public List<Crew> crew { get; set; }
    }


    
    public class Cast
    {
        public int cast_id { get; set; }

        private string firstcharacter;

        public string character
        {
            get { return firstcharacter; }
            set
            {
                string[] splitted = value.Split('/');
                firstcharacter = splitted[0];
            }
        }

        public string credit_id { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int order { get; set; }
        private Uri _profile_path;

        public string profile_path {
            get { return _profile_path.ToString(); }
            set { _profile_path = new Uri(Constants.posterBase + value); }
        }

    }

    public class Crew
    {
        public string credit_id { get; set; }
        public string department { get; set; }
        public int gender { get; set; }
        public int id { get; set; }
        public string job { get; set; }
        public string name { get; set; }
        public string profile_path { get; set; }
    }

}
