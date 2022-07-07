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
    public class BookController : ApiController
    {
        // GET api/<controller>

        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet]
        [Route("api/Book")]
        public List<Book> Get(string email)
        {
            DBservices ds = new DBservices();
            List<Book> userBooks = ds.GetUser_Books(email);
            //Book book = new Book();
            //userBooks= book.GetUser_Books(email);
            return userBooks;
        }

        // POST api/<controller>
        public int Post([FromBody]Book book)
        {
            return book.InsertBook();
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