using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialTravel.Models
{
    public class Address
    {
        public int address_id
        {
            get;
            set;
        }

        public int house_no
        {
            get;
            set;
        }
        public int block
        {
            get;
            set;
        }
        public int street
        {
            get;
            set;
        }
        public string area
        {
            get;
            set;
        }
        public string town
        {
            get;
            set;
        }
        public int user_id
        {
            get;
            set;
        }
    }
}