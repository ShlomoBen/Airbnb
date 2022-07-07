using FinalProj.Models.DAL;
using Newtonsoft.Json.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
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
        String date_register;
        int totalPrice;



        public User()
        {

        }

        public User(string username, string email, string password, string date_register, int totalPrice)
        {
            this.username = username;
            this.email = email;
            this.password = password;
            this.date_register = date_register;
            this.totalPrice = totalPrice;

        }

        public string Username { get => username; set => username = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public string Date_register { get => date_register; set => date_register = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }


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

        public User Read(string email)
        {
            DBservices ds = new DBservices();
            return ds.GetUser_ByEmail(email);
        }


        public int ChangePrice(string email,int totalPrice,int newPrice)
        {

            DBservices dbs = new DBservices();
            dbs = dbs.readUserBy_Email(email);
            dbs.dt = ChangePriceTable(email, totalPrice, newPrice, dbs.dt);
            dbs.update();
            return 0;

        }

        public DataTable ChangePriceTable(string email, int totalPrice, int newPrice, DataTable dt)
        {
            foreach (DataRow dr in dt.Rows)
            {
                    int totalPrice1 = Convert.ToInt32(dr["totalPrice"]);
                    dr["totalPrice"] = totalPrice1 + newPrice;
                
            }
            return dt;
        }


    }

   






}