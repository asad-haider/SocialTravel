using SocialTravel.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SocialTravel.Controllers
{
    [RoutePrefix("api/address")]
    public class AddressController : ApiController
    {
        [HttpGet]
        [Route("findAll")]
        public List<Address> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                return ste.App_Address.Select(aa => new Address
                {

                    address_id = aa.address_id,
                    user_id = aa.user_id,
                    town = aa.town,
                    block = aa.block,
                    street = aa.street,
                    house_no = aa.house_no,
                    area = aa.area,

                }).ToList();
            };
        }

        [HttpGet]
        [Route("find/{address_id:int}")]
        public Address find(int address_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(address_id);
                return ste.App_Address.Where(aa => aa.address_id == nid).Select(aa => new Address
                {

                    address_id = aa.address_id,
                    user_id = aa.user_id,
                    town = aa.town,
                    block = aa.block,
                    street = aa.street,
                    house_no = aa.house_no,
                    area = aa.area,
                }).First();
            };
        }

        [HttpPost]
        [Route("create")]
        public bool create(Address address)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_Address aa = new App_Address();
                    aa.address_id = address.address_id;
                    aa.user_id = address.user_id;
                    aa.town = address.town;
                    aa.block = address.block;
                    aa.street = address.street;
                    aa.house_no = address.house_no;
                    aa.area = address.area;

                
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
        public bool edit(Address address)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    int address_id = Convert.ToInt32(address.address_id);
                    App_Address aa = ste.App_Address.Single(a => a.address_id == address.address_id);

                    //aa.address_id = address.address_id;
                    aa.user_id = address.user_id;
                    aa.town = address.town;
                    aa.house_no = address.house_no;
                    aa.street = address.street;
                    aa.block = address.block;
                    aa.area = address.area;

                    ste.App_Address.Add(aa);
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
                    var address = new App_Address { address_id = id };
                    ste.App_Address.Attach(address);
                    ste.App_Address.Remove(address);
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
