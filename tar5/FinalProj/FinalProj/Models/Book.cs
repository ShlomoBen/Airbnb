using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace FinalProj.Models
{
    public class Book
    {
        private int order_id;
        private String propertyId;
        private String fName;
        private String lName;
        private String email;
        private String pplNum;
        private String checkIn;
        private String checkOut;
        private String vaild;
        private int price;
        private String date_register;

        public Book(int order_id,String propertyId, string fName, string lName, string email, String pplNum, string checkIn, string checkOut, string vaild, int price, string date_register)
        {
            this.order_id = order_id;
            this.propertyId = propertyId;
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.pplNum = pplNum;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.vaild = vaild;
            this.price = price;
            this.date_register = date_register;
        }
        public Book() { }

        public int Order_id { get => order_id; set => order_id = value; }
        public String PropertyId { get => propertyId; set => propertyId = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Email { get => email; set => email = value; }
        public String PplNum { get => pplNum; set => pplNum = value; }
        public string CheckIn { get => checkIn; set => checkIn = value; }
        public string CheckOut { get => checkOut; set => checkOut = value; }
        public string Vaild { get => vaild; set => vaild = value; }
        public int Price { get => price; set => price = value; }
        public string Date_register { get => date_register; set => date_register = value; }

        public int InsertBook()
        {
            DBservices DB = new DBservices();
            return DB.InsertBook(this);
        }

        public List<Book> GetUser_Books(string email)
        {
            DBservices DB = new DBservices();
            return DB.GetUser_Books(email);
        }

        public List<Book> ReadAllBooks()
        {
            DBservices DB = new DBservices();
            return DB.GetAllUsers_Books();
        }


        public int ChangeVaild(int orderId,string vaild)
        {
            DBservices ds = new DBservices();
            return ds.ChangeVaild(orderId, vaild);

        }




    }
}