using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialTravel.Models
{
    public class CarPool
    {
        public int car_pool_id { get; set; }
        public System.DateTime car_pool_created_date { get; set; }
        public string to_ { get; set; }
        public string from_ { get; set; }
        public System.DateTime effective_from { get; set; }
        public System.DateTime effective_to { get; set; }
        public int no_of_seats_available { get; set; }
        public int cost_per_seat { get; set; }
        public bool round_trip { get; set; }
        public int wait_time { get; set; }
        public string description { get; set; }
        public int approx_reach_time { get; set; }
        public bool smoking { get; set; }
        public bool food { get; set; }
        public int user_id { get; set; }
    }
}