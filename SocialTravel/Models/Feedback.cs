using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialTravel.Models
{
    public class Feedback
    {
        public int car_pool_id { get; set; }
        public int user_id { get; set; }
        public System.DateTime created_date { get; set; }
        public string feedback_description { get; set; }
        public int rating { get; set; }
    }
}