using FinalProj.Models;
using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FinalProj.Controllers
{
    public class PropertyController : ApiController
    {
        // GET api/<controller>
        public IEnumerable<Property> Get()
        {
            Property p = new Property();
            List<Property> pList = p.GetAllProperties();
            return pList;
        }

        [HttpGet]
        [Route("api/PropertyDetails")]
        public Property Get(string id)
        {
            DBservices ds = new DBservices();
            Property p = new Property();
            p = ds.GetPropertyDetails(id);
            return p;
        }


        //// "../api/PropertySearch?pricefrom="+ "&priceto=" + "&checkin=" + "&checkout=" + "&score=" + "&distance=" + "&rooms ;
        [HttpGet]
        [Route("api/PropertySearch")]
        public IEnumerable<Property> Get(int pricefrom, int priceto, string checkin, string checkout, float score, float distance, int bedrooms)
        {
            DBservices ds = new DBservices();
            List<Property> pList = ds.GetPropertiesBySearch(pricefrom, priceto, checkin, checkout, score, distance, bedrooms); // need to create search func in ds    
            return pList;
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}