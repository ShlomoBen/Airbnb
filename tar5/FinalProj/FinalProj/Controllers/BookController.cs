using FinalProj.Models;
using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;

namespace FinalProj.Controllers
{
    public class BookController : ApiController
    {
        // GET api/<controller>

        public List<Book> Get()
        {
            Book b = new Book();
            return b.ReadAllBooks();
        }

        // GET api/<controller>/5
        public List<Book> Get(string email)
        {
            DBservices ds = new DBservices();
            List<Book> userBooks = ds.GetUser_Books(email);
            return userBooks;
        }

        // POST api/<controller>
        public int Post([FromBody]Book book)
        {
            return book.InsertBook();
        }


        // Put api/<controller>
        public int Put([FromBody] JObject data)
        {
            int orderId = Convert.ToInt32(data["orderId"]);
            string vaild = data["vaild"].ToString();
            Book b = new Book();
            return b.ChangeVaild(orderId, vaild);
        }


        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}