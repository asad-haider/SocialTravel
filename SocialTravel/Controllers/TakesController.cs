using SocialTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialTravel.Controllers
{
    [RoutePrefix("api/takes")]
    public class TakesController : ApiController
    {
        [HttpGet]
        [Route("findAll")]
        public List<Takes> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                return ste.App_Takes.Select(t => new Takes
                {
                    car_pool_id = t.car_pool_id,
                    user_id = t.user_id,
                    booking_date = t.booking_date,
                    unbook_date = t.unbook_date,
                    no_of_seats_booked = t.no_of_seats_booked,

                }).ToList();
            };
        }

        [HttpGet]
        [Route("find/{user_id:int}")]
        public Takes find(int user_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(user_id);
                return ste.App_Takes.Where(t => t.user_id == nid).Select(t => new Takes
                {
                    car_pool_id = t.car_pool_id,
                    user_id = t.user_id,
                    booking_date = t.booking_date,
                    unbook_date = t.unbook_date,
                    no_of_seats_booked = t.no_of_seats_booked,

                }).First();
            };
        }

        [HttpPost]
        [Route("create")]
        public bool create(Takes takes)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_Takes t = new App_Takes();
                    t.car_pool_id = takes.car_pool_id;
                    t.user_id = takes.user_id;
                    t.booking_date = takes.booking_date;
                    t.unbook_date = takes.unbook_date;
                    t.no_of_seats_booked = takes.no_of_seats_booked;

                    return true;
                }

                catch
                {
                    return false;
                }
            };
        }

        [HttpPut]
        [Route("edit")]
        public bool edit(Takes takes)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    int user_id = Convert.ToInt32(takes.user_id);
                    App_Takes t = ste.App_Takes.Single(at => at.user_id == takes.user_id);

                    t.car_pool_id = takes.car_pool_id;
                    t.booking_date = takes.booking_date;
                    t.unbook_date = takes.unbook_date;
                    t.no_of_seats_booked = takes.no_of_seats_booked;

                    ste.App_Takes.Add(t);
                    ste.SaveChanges();

                    return true;
                }

                catch
                {
                    return false;
                }
            };
        }


        [HttpDelete]
        [Route("delete/{id:int}")]
        public bool delete(int id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    var takes = new App_Takes { user_id = id };
                    ste.App_Takes.Attach(takes);
                    ste.App_Takes.Remove(takes);
                    ste.SaveChanges();

                    return true;
                }

                catch
                {
                    return false;
                }
            };
        }
    }
}
