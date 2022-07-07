using FinalProj.Models.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProj.Models
{
    public class Book
    {
        int orederId;
        int propertyId;
        String fName;
        String lName;
        String email;
        int pplNum;
        String checkIn;
        String checkOut;
        String vaild;

        public int OrederId { get => orederId; set => orederId = value; }
        public int PropertyId { get => propertyId; set => propertyId = value; }
        public string FName { get => fName; set => fName = value; }
        public string LName { get => lName; set => lName = value; }
        public string Email { get => email; set => email = value; }
        public int PplNum { get => pplNum; set => pplNum = value; }
        public string CheckIn { get => checkIn; set => checkIn = value; }
        public string CheckOut { get => checkOut; set => checkOut = value; }
        public string Vaild { get => vaild; set => vaild = value; }

        public Book(int orederId, int propertyId, string fName, string lName, string email, int pplNum, string checkIn, string checkOut, string vaild)
        {
            this.orederId = orederId;
            this.propertyId = propertyId;
            this.fName = fName;
            this.lName = lName;
            this.email = email;
            this.pplNum = pplNum;
            this.checkIn = checkIn;
            this.checkOut = checkOut;
            this.vaild = vaild;
        }

        public Book()
        {

        }

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

    }
}