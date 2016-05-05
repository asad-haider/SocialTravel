using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialTravel.Models
{
    public class DriverSchedule
    {
        public int car_pool_id { get; set; }
        public string day { get; set; }
        public System.DateTime leaving_time { get; set; }
        public System.DateTime reaching_time { get; set; }
    }
}