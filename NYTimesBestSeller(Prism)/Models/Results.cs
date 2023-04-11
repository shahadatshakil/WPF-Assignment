using System.Collections.Generic;

namespace NYTimesBestSeller_Prism_.Models
{
    public class Results
    {
        public string list_name { get; set; }
        public string list_name_encoded { get; set; }
        public string bestsellers_date { get; set; }
        public string published_date { get; set; }
        public string published_date_description { get; set; }
        public string next_published_date { get; set; }
        public string previous_published_date { get; set; }
        public string display_name { get; set; }
        public int normal_list_ends_at { get; set; }
        public string updated { get; set; }
        public List<Book> books { get; set; }
        public List<object> corrections { get; set; }
    }
}
