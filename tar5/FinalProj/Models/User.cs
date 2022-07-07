using FinalProj.Models.DAL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace FinalProj.Models
{
    public class User
    {
        String username;
        String password;
        String email;

        public User()
        {

        }

        public User(string username, string email, string password)
        {
            this.username = username;
            this.email = email;
            this.password = password;

        }

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        


        public int InsertUser()
        {
            DBservices ds = new DBservices();
            return ds.InsertUser(this);
        }

        public List<User> GetUsers()
        {
            DBservices DB = new DBservices();
            return DB.GetUsers();
        }
    }

   






}