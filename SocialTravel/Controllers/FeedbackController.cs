using SocialTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialTravel.Controllers
{

    [RoutePrefix("api/feedback")]
    public class FeedbackController : ApiController
    {
        [HttpGet]
        [Route("findAll")]
        public List<Feedback> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                return ste.App_Feedback.Select(fb => new Feedback
                {

                    car_pool_id = fb.car_pool_id,
                    user_id = fb.user_id,
                    rating = fb.rating,
                    feedback_description = fb.feedback_description,
                    created_date = fb.created_date,

                }).ToList();
            };
        }

        [HttpGet]
        [Route("find/{user_id:int}")]
        public Feedback find(string user_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(user_id);
                return ste.App_Feedback.Where(fb => fb.user_id == nid).Select(fb => new Feedback
                {

                    car_pool_id = fb.car_pool_id,
                    user_id = fb.user_id,
                    rating = fb.rating,
                    feedback_description = fb.feedback_description,
                    created_date = fb.created_date,

                }).First();
            };
        }


        [HttpPost]
        [Route("create")]
        public bool create(Feedback feedback)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_Feedback fb = new App_Feedback();
                    fb.car_pool_id = feedback.car_pool_id;
                    fb.user_id = feedback.user_id;
                    fb.created_date = feedback.created_date;
                    fb.rating = feedback.rating;
                    fb.feedback_description = feedback.feedback_description;

                    ste.App_Feedback.Add(fb);
                    ste.SaveChanges();

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
        public bool edit(Feedback feedback)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    int user_id = Convert.ToInt32(feedback.user_id);
                    App_Feedback fb = ste.App_Feedback.Single(f => f.user_id == feedback.user_id);

                    //fb.car_pool_id = feedback.car_pool_id;
                    fb.user_id = feedback.user_id;
                    fb.created_date = feedback.created_date;
                    fb.rating = feedback.rating;
                    fb.feedback_description = feedback.feedback_description;
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
                    var feedback = new App_Feedback { user_id = id };
                    ste.App_Feedback.Attach(feedback);
                    ste.App_Feedback.Remove(feedback);
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
