using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialTravel.Models
{
    public class Takes
    {
        public int user_id { get; set; }
        public int car_pool_id { get; set; }
        public int no_of_seats_booked { get; set; }
        public System.DateTime booking_date { get; set; }
        public System.DateTime unbook_date { get; set; }
    }
}