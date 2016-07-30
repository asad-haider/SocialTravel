using SocialTravel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SocialTravel.Controllers
{
    [RoutePrefix("api/carpool")]
    public class CarPoolController : ApiController
    {

        [HttpGet]
        [Route("findAll")]
        public List<CarPool> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                return ste.App_Car_Pool.Select(cp => new CarPool
                {
                    car_pool_id = cp.car_pool_id,
                    car_pool_created_date = cp.car_pool_created_date,
                    to_ = cp.to_,
                    from_ = cp.from_,
                    effective_from = cp.effective_from,
                    effective_to = cp.effective_to,
                    no_of_seats_available = cp.no_of_seats_available,
                    cost_per_seat = cp.cost_per_seat,
                    round_trip = cp.round_trip,
                    wait_time = cp.wait_time,
                    description = cp.description,
                    approx_reach_time = cp.approx_reach_time,
                    smoking = cp.smoking,
                    food = cp.food,
                    user_id = cp.user_id,


                }).ToList();
            };
        }

        [HttpGet]
        [Route("find/{car_pool_id:int}")]
        public CarPool find(int car_pool_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(car_pool_id);
                return ste.App_Car_Pool.Where(cp => cp.car_pool_id == nid).Select(cp => new CarPool
                {
                    car_pool_id = cp.car_pool_id,
                    car_pool_created_date = cp.car_pool_created_date,
                    to_ = cp.to_,
                    from_ = cp.from_,
                    effective_from = cp.effective_from,
                    effective_to = cp.effective_to,
                    no_of_seats_available = cp.no_of_seats_available,
                    cost_per_seat = cp.cost_per_seat,
                    round_trip = cp.round_trip,
                    wait_time = cp.wait_time,
                    description = cp.description,
                    approx_reach_time = cp.approx_reach_time,
                    smoking = cp.smoking,
                    food = cp.food,
                    user_id = cp.user_id,


                }).First();
            };
        }

        [HttpGet]
        [Route("search")]
        public List<CarPool> search(string from, string to)
        {
            using (SocialTravel ste = new SocialTravel())
            {

                var result = ste.App_Car_Pool.Where(cp => cp.from_ == from && cp.to_ == to).Select(cp => new CarPool
                {
                    car_pool_id = cp.car_pool_id,
                    car_pool_created_date = cp.car_pool_created_date,
                    to_ = cp.to_,
                    from_ = cp.from_,
                    effective_from = cp.effective_from,
                    effective_to = cp.effective_to,
                    no_of_seats_available = cp.no_of_seats_available,
                    cost_per_seat = cp.cost_per_seat,
                    round_trip = cp.round_trip,
                    wait_time = cp.wait_time,
                    description = cp.description,
                    approx_reach_time = cp.approx_reach_time,
                    smoking = cp.smoking,
                    food = cp.food,
                    user_id = cp.user_id,

                });

                return result.ToList();

            };
        }

       
        [HttpPost]
        [Route("create")]
        public bool create(CarPool carpool)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_Car_Pool cp = new App_Car_Pool();
                    cp.car_pool_id = carpool.car_pool_id;
                    cp.car_pool_created_date = carpool.car_pool_created_date;
                    cp.to_ = carpool.to_;
                    cp.from_ = carpool.from_;
                    cp.effective_from = carpool.effective_from;
                    cp.effective_to = carpool.effective_to;
                    cp.no_of_seats_available = carpool.no_of_seats_available;
                    cp.cost_per_seat = carpool.cost_per_seat;
                    cp.round_trip = carpool.round_trip;
                    cp.wait_time = carpool.wait_time;
                    cp.description = carpool.description;
                    cp.approx_reach_time = carpool.approx_reach_time;
                    cp.smoking = carpool.smoking;
                    cp.food = carpool.food;
                    cp.user_id = carpool.user_id;

                    ste.App_Car_Pool.Add(cp);
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
        public bool edit(CarPool carpool)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    int car_pool_id = Convert.ToInt32(carpool.car_pool_id);
                    App_Car_Pool cp = ste.App_Car_Pool.Single(c => c.car_pool_id == carpool.car_pool_id);

                    cp.car_pool_created_date = carpool.car_pool_created_date;
                    cp.to_ = carpool.to_;
                    cp.from_ = carpool.from_;
                    cp.effective_from = carpool.effective_from;
                    cp.effective_to = carpool.effective_to;
                    cp.no_of_seats_available = carpool.no_of_seats_available;
                    cp.cost_per_seat = carpool.cost_per_seat;
                    cp.round_trip = carpool.round_trip;
                    cp.wait_time = carpool.wait_time;
                    cp.description = carpool.description;
                    cp.approx_reach_time = carpool.approx_reach_time;
                    cp.smoking = carpool.smoking;
                    cp.food = carpool.food;
                    cp.user_id = carpool.user_id;
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
                    var carpool = new App_Car_Pool { car_pool_id = id };
                    ste.App_Car_Pool.Attach(carpool);
                    ste.App_Car_Pool.Remove(carpool);
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
