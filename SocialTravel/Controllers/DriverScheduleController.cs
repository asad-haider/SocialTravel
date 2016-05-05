using SocialTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialTravel.Controllers
{
    [RoutePrefix("api/driverschedule")]
    public class DriverScheduleController : ApiController
    {
        [HttpGet]
        [Route("findAll")]
        public List<DriverSchedule> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                return ste.App_Driver_Schedule.Select(ds => new DriverSchedule
                {

                    car_pool_id = ds.car_pool_id,
                    leaving_time = ds.leaving_time,
                    reaching_time = ds.reaching_time,
                    day = ds.day,

                }).ToList();
            };
        }

        [HttpGet]
        [Route("find/{car_pool_id:int}")]
        public DriverSchedule find(int car_pool_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(car_pool_id);
                return ste.App_Driver_Schedule.Where(ds => ds.car_pool_id == nid).Select(ds => new DriverSchedule
                {

                    car_pool_id = ds.car_pool_id,
                    leaving_time = ds.leaving_time,
                    reaching_time = ds.reaching_time,
                    day = ds.day,

                }).First();

            };
        }

        [HttpPost]
        [Route("create")]
        public bool create(DriverSchedule driverSch)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_Driver_Schedule ds = new App_Driver_Schedule();
                    ds.car_pool_id = driverSch.car_pool_id;
                    ds.leaving_time = driverSch.leaving_time;
                    ds.reaching_time = driverSch.reaching_time;
                    ds.day = driverSch.day;

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
        public bool edit(DriverSchedule driverSch)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    int car_pool_id = Convert.ToInt32(driverSch.car_pool_id);
                    App_Driver_Schedule ds = ste.App_Driver_Schedule.Single(d => d.car_pool_id == driverSch.car_pool_id);
                    //ds.car_pool_id = driverSch.car_pool_id;
                    ds.leaving_time = driverSch.leaving_time;
                    ds.reaching_time = driverSch.reaching_time;
                    ds.day = driverSch.day;

                    ste.App_Driver_Schedule.Add(ds);
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

                    var driverSchedule = new App_Driver_Schedule { car_pool_id = id };
                    ste.App_Driver_Schedule.Attach(driverSchedule);
                    ste.App_Driver_Schedule.Remove(driverSchedule);
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
