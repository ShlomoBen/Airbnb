using FinalProj.Models;
using FinalProj.Models.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProj.Controllers
{
    public class UserController : ApiController
    {
        // GET api/<controller>
        public List<User> Get()
        {
            User user = new User();
            return user.GetUsers(); 
        }

        // GET api/<controller>/mail/password
        public HttpResponseMessage Get(string email, string password)
        {
            DBservices ds = new DBservices();
            User user = ds.validLoginFromDB(email, password);
            if(user.Email == email && user.Password == password)
            {
                return Request.CreateResponse(HttpStatusCode.OK, user);
                
            }
            return Request.CreateResponse(HttpStatusCode.NotFound, "Email adress or Password is incorrect");
    
        }

        // GET api/<controller>/mail
        public User Get(string email)
        {
            User user = new User();
            return user.Read(email);
        }



        // POST api/<controller>
        public int Post([FromBody]User user)
        {
            return user.InsertUser();
        }


        [HttpPut]
        [Route("api/ChangePrice")]
        public int Put([FromBody] JObject data)
        {
            string email = data["email"].ToString();
            int totalPrice = Convert.ToInt32(data["totalPrice"]);
            int newPrice = Convert.ToInt32(data["newPrice"]);

            User u = new User();
             return u.ChangePrice(email, totalPrice, newPrice);
            
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}