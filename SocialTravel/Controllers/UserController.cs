using API.Models;
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
    [RoutePrefix("api/user")]
    public class UserController : ApiController
    {

        [HttpGet]
        [Route("findAll")]
        public List<User> findAll()
        {
            using (SocialTravel ste = new SocialTravel())
            {
                List<User> users = new List<User>();

                List<App_User> appUsers = ste.App_User.ToList();

                foreach (var user in appUsers)
                {
                    users.Add(new User
                    {
                        user_id = user.user_id,
                        user_description = user.user_description,
                        user_name = user.user_name,
                        user_password = user.user_password,
                        phone_No = user.phone_No,
                        email = user.email,
                        profile_picture = user.profile_picture,
                        address_id = user.address_id,
                        gender = user.gender,
                        black_list = user.black_list

                    });
                }

                return users;
            };
        }


        [HttpGet]
        [Route("find/{user_id:int}")]
        public User find(string user_id)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                int nid = Convert.ToInt32(user_id);

                return ste.App_User.Where(u => u.user_id == nid).Select(u => new User
                {

                    user_id = u.user_id,
                    user_description = u.user_description,
                    user_name = u.user_name,
                    user_password = u.user_password,
                    phone_No = u.phone_No,
                    email = u.email,
                    profile_picture = u.profile_picture,
                    address_id = u.address_id,
                    gender = u.gender,
                    black_list = u.black_list
                }).First();
            };
        }

        [HttpPost]
        [Route("create")]
        public bool create(User user)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_User u = new App_User();

                    u.user_id = user.user_id;
                    u.user_description = user.user_description;
                    u.user_name = user.user_name;
                    u.user_password = user.user_password;
                    u.phone_No = user.phone_No;
                    u.email = user.email;
                    u.profile_picture = user.profile_picture;
                    u.address_id = user.address_id;
                    u.gender = user.gender;
                    u.black_list = user.black_list;

                    ste.App_User.Add(u);
                    ste.SaveChanges();

                    return true;
                }

                catch
                {
                    return false;
                }
            };
        }

        [HttpPost]
        [Route("login")]
        public User Login(User user)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    var result = ste.App_User.Where(u => u.email == user.email & u.user_password == user.user_password).Select(u => new User
                    {

                        user_id = u.user_id,
                        user_description = u.user_description,
                        user_name = u.user_name,
                        user_password = u.user_password,
                        phone_No = u.phone_No,
                        email = u.email,
                        profile_picture = u.profile_picture,
                        address_id = u.address_id,
                        gender = u.gender,
                        black_list = u.black_list
                    }).SingleOrDefault();

                    return result;
                }
                catch
                {
                    return null;
                }
            };
        }

        [HttpPost]
        [Route("upload")]
        public string UploadFile(int userId)
        {
            var file = HttpContext.Current.Request.Files.Count > 0 ?
                HttpContext.Current.Request.Files[0] : null;

            if (file != null && file.ContentLength > 0)
            {
                var fileName = Path.GetFileName(file.FileName);

                var directory = HttpContext.Current.Server.MapPath("~/uploads");

                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                }

                var path = Path.Combine(
                    directory,
                    fileName
                );
 
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                file.SaveAs(path);

                if (file != null)
                {
                    using (SocialTravel ste = new SocialTravel())
                    {
                            App_User u = ste.App_User.Single(au => au.user_id == userId);
                            u.profile_picture = path;
                            ste.SaveChanges();
                            
                        
                    };
                }
                return file != null ? "/uploads/" + file.FileName : null;
            }
            else
            {
                return null;
            }          
        }

        [HttpPut]
        [Route("edit")]
        public bool edit(User user)
        {
            using (SocialTravel ste = new SocialTravel())
            {
                try
                {
                    App_User u = ste.App_User.Single(au => au.user_id == user.user_id);

                    u.user_description = user.user_description;
                    u.user_name = user.user_name;
                    u.user_password = user.user_password;
                    u.phone_No = user.phone_No;
                    u.email = user.email;
                    u.profile_picture = user.profile_picture;
                    u.address_id = user.address_id;
                    u.gender = user.gender;
                    u.black_list = user.black_list;
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
                    var user = new App_User { user_id = id };
                    ste.App_User.Attach(user);
                    ste.App_User.Remove(user);
                    ste.SaveChanges();
                    
                    return true;
                }

                catch(Exception e)
                {
                    return false;
                }
            };
        }
    }
}