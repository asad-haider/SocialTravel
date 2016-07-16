using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Models
{
    public class User
    {
        public int user_id { get; set; }
        public string user_description { get; set; }
        public string user_name { get; set; }
        public string user_password { get; set; }
        public int phone_No { get; set; }
        public string email { get; set; }
        public string profile_picture { get; set; }
        public int address_id { get; set; }
        public string gender { get; set; }
        public bool black_list { get; set; }

        public User()
        {

        }
    }
}