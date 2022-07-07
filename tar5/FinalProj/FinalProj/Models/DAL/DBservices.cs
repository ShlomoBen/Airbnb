using FinalProj.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Web.Configuration;
using System.Collections;
using System.Text;

namespace FinalProj.Models.DAL
{
    public class DBservices
    {
        public SqlDataAdapter da;
        public DataTable dt;

        static List<User> userList = new List<User>();
        static List<Property> propertiesList = new List<Property>();

        //--------Get property For details---------------------------------------
        public Property GetPropertyDetails(string id)
        {
            SqlConnection con = null;
            Property p = new Property();

            try
            {
                con = Connect("DBConnectionString");//create connect to the database using the the connection string in web config file

                //String selectSTR = "SELECT * FROM listing100CSV WHERE id="+id;

                String selectSTR = "SELECT * " +
                                    "FROM listing100CSV as L inner join(SELECT id, geography::Point(52.3728953, 4.8946891, 4326).STDistance(geography::Point(latitude, longitude, 4326)) as distance " +
                                    "FROM listing100CSV) as D on L.id = D.id WHERE L.id=" + id;


                SqlCommand cmd = new SqlCommand(selectSTR, con);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {
                    //read till the end of the data per row
                    
                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Description = dr["description"].ToString();
                    p.Neighborhood_overview = dr["neighborhood_overview"].ToString();
                    p.Picture_url = dr["picture_url"].ToString();
                    p.Property_type = dr["property_type"].ToString();
                    p.Room_type = dr["room_type"].ToString();
                    p.Accommodates = dr["accommodates"].ToString();
                    p.Bathrooms = float.Parse(dr["bathrooms"].ToString());
                    p.Bedrooms = (dr["bedrooms"] != System.DBNull.Value) ? Convert.ToInt32(dr["bedrooms"]) : 0;
                    p.Beds = Convert.ToInt32(dr["beds"]);
                    p.Amenities = dr["amenities"].ToString();
                    p.Price = p.Price = Convert.ToInt32(dr["price"]);
                    p.Review_scores_rating = float.Parse(dr["Review_scores_rating"].ToString());
                    p.Latitude = float.Parse(dr["Latitude"].ToString());
                    p.Longitude = float.Parse(dr["Longitude"].ToString());
                    p.Minimum_nights = Convert.ToInt32(dr["minimum_nights"]);
                    p.Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);
                    p.Distance = float.Parse(dr["distance"].ToString());

                }
                return p;
            }
            catch (Exception ex)
            {
                //write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        //--Get properties by search func----------------------------------------------
        public List<Property> GetPropertiesBySearch(int pricefrom, int priceto, string checkin, string checkout, float score, float distance, int bedrooms)
        {
            SqlConnection con = null;
            List<Property> propertiesListResults = new List<Property>();

            try
            {
                con = Connect("DBConnectionString");//create connect to the database using the the connection string in web config file

               
                String selectSTR = "SELECT * " +
                                    "FROM listing100CSV as L inner join(SELECT id, geography::Point(52.3728953, 4.8946891, 4326).STDistance(geography::Point(latitude, longitude, 4326)) as distance " +
                                    "FROM listing100CSV) as D on L.id = D.id " +
                                    "WHERE price BETWEEN " + pricefrom + " AND " + priceto + " and review_scores_rating >=" + score +
                                   " and bedrooms=" + bedrooms + " and distance <=" + distance;


                    SqlCommand cmd = new SqlCommand(selectSTR, con);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {
                    //read till the end of the data per row
                    Property p = new Property();

                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Description = dr["description"].ToString();
                    p.Neighborhood_overview = dr["neighborhood_overview"].ToString();
                    p.Picture_url = dr["picture_url"].ToString();
                    p.Property_type = dr["property_type"].ToString();
                    p.Room_type = dr["room_type"].ToString();
                    p.Accommodates = dr["accommodates"].ToString();
                    p.Bathrooms = float.Parse(dr["bathrooms"].ToString());
                    p.Bedrooms = (dr["bedrooms"] != System.DBNull.Value) ? Convert.ToInt32(dr["bedrooms"]) : 0;
                    p.Beds = Convert.ToInt32(dr["beds"]);
                    p.Amenities = dr["amenities"].ToString();
                    p.Price = Convert.ToInt32(dr["price"]);
                    p.Review_scores_rating = float.Parse(dr["Review_scores_rating"].ToString()); 
                    p.Latitude = float.Parse(dr["Latitude"].ToString());
                    p.Longitude = float.Parse(dr["Longitude"].ToString());
                    p.Minimum_nights = Convert.ToInt32(dr["minimum_nights"]);
                    p.Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);
                    p.Distance = float.Parse(dr["distance"].ToString());
                    propertiesListResults.Add(p);
                }
                
                return propertiesListResults;
            }
            catch (Exception ex)
            {
                //write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }



        //--Get all properties func----------------------------------------------
        public List<Property> GetAllProperties()
        {
            SqlConnection con = null;
            List<Property> propertiesList = new List<Property>();

            try
            {
                con = Connect("DBConnectionString");//create connect to the database using the the connection string in web config file

                String selectSTR = "SELECT * FROM listing100CSV";
                SqlCommand cmd = new SqlCommand(selectSTR, con); 

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                

                while (dr.Read())
                {
                    //read till the end of the data per row
                    Property p = new Property();

                    p.Id = Convert.ToInt32(dr["id"]);
                    p.Name = dr["name"].ToString();
                    p.Description = dr["description"].ToString();
                    p.Neighborhood_overview = dr["neighborhood_overview"].ToString();
                    p.Picture_url = dr["picture_url"].ToString();
                    p.Property_type = dr["property_type"].ToString();
                    p.Room_type = dr["room_type"].ToString();
                    p.Accommodates = dr["accommodates"].ToString();
                    p.Bathrooms = float.Parse(dr["bathrooms"].ToString());
                    p.Bedrooms = (dr["bedrooms"] != System.DBNull.Value) ? Convert.ToInt32(dr["bedrooms"]) : 0;
                    p.Beds = Convert.ToInt32(dr["beds"]);
                    p.Amenities = dr["amenities"].ToString();
                    p.Price = p.Price = Convert.ToInt32(dr["price"]);
                    p.Review_scores_rating = float.Parse(dr["Review_scores_rating"].ToString());
                    p.Latitude = float.Parse(dr["Latitude"].ToString());
                    p.Longitude = float.Parse(dr["Longitude"].ToString());
                    p.Minimum_nights = Convert.ToInt32(dr["minimum_nights"]);
                    p.Maximum_nights = Convert.ToInt32(dr["maximum_nights"]);

                    propertiesList.Add(p);
                }
                return propertiesList;
            }
            catch (Exception ex)
            {
                //write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }





        //--Valid and login user-------------------------------------------------------------------------------
        public User validLoginFromDB(String mail, String password)
        {
            SqlConnection con = null;

            try
            {
                con = Connect("DBConnectionString");//create connect to the database using the the connection string in web config file

                String selectSTR = "SELECT * FROM Users WHERE email =" + "'" + mail + "'" + " and password = " + "'" + password + "' ";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end
                User user = new User();

                while (dr.Read())
                {
                    //read till the end of the data per row
                    user.Username = (String)dr["user"];
                    user.Password = (String)dr["password"];
                    user.Email = (String)dr["email"];
                    user.Date_register = (String)dr["date_register"];
                    user.TotalPrice = Convert.ToInt16(dr["totalPrice"]);


                }
                return user;
            }
            catch(Exception ex)
            {
                //write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }





        //-------------------------------------Insert Book-------------------------------------------------
        public int InsertBook(Book book)
        {
            SqlConnection con = Connect("DBConnectionString");

            // Create Command
            SqlCommand command = CreateInsertCommand_Book(con, book);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection

            con.Close();

            return numAffected;
        }

        private SqlCommand CreateInsertCommand_Book(SqlConnection con, Book book)
        {
            SqlCommand command = new SqlCommand();
               
            command.Parameters.AddWithValue("@property_id", book.PropertyId);
            command.Parameters.AddWithValue("@first_name", book.FName);
            command.Parameters.AddWithValue("@last_name", book.LName);
            command.Parameters.AddWithValue("@email", book.Email);
            command.Parameters.AddWithValue("@ppl_num", book.PplNum);
            command.Parameters.AddWithValue("@check_in", book.CheckIn);
            command.Parameters.AddWithValue("@check_out", book.CheckOut);
            command.Parameters.AddWithValue("@vaild", book.Vaild);
            command.Parameters.AddWithValue("@price", book.Price);
            command.Parameters.AddWithValue("@date_register", book.Date_register);

            command.CommandText = "spInsertBook";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }


        //------Get All Users_Books ----------

        public List<Book> GetAllUsers_Books()
        {

            SqlConnection con = Connect("DBConnectionString");
            List<Book> All_usersBooksList = new List<Book>();

            SqlCommand cmd = CreateGetAllUsers_Books(con);

            //get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


            while (dr.Read())
            {
                //read till the end of the data per row
                Book userBooks = new Book();

                userBooks.Order_id = Convert.ToInt16(dr["order_id"]);
                userBooks.PropertyId = (String)dr["property_id"];
                userBooks.FName = (String)dr["first_name"];
                userBooks.LName = (String)dr["last_name"];
                userBooks.Email = (String)dr["email"];
                userBooks.PplNum = (String)dr["ppl_num"];
                userBooks.CheckIn = (String)dr["check_in"];
                userBooks.CheckOut = (String)dr["check_out"];
                userBooks.Vaild = (String)dr["vaild"];
                userBooks.Price = Convert.ToInt16(dr["price"]);
                userBooks.Date_register = (String)dr["date_register"];

                All_usersBooksList.Add(userBooks);
            }
            con.Close();

            return All_usersBooksList;

        }

        private SqlCommand CreateGetAllUsers_Books(SqlConnection con)
        {

            SqlCommand command = new SqlCommand();

            command.CommandText = "SPGetAllBooks";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }




        //-------------Get Books by Email----------------

        public List<Book> GetUser_Books(String email)
        {
         
                SqlConnection con = Connect("DBConnectionString"); 
                List<Book> userBooksList = new List<Book>();

                SqlCommand cmd = CreateGetUser_Books(con, email);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {
                    //read till the end of the data per row
                    Book userBooks = new Book();

                    userBooks.Order_id = Convert.ToInt16(dr["order_id"]);
                    userBooks.PropertyId = (String)dr["property_id"];
                    userBooks.FName = (String)dr["first_name"];
                    userBooks.LName = (String)dr["last_name"];
                    userBooks.Email = (String)dr["email"];
                    userBooks.PplNum = (String)dr["ppl_num"];
                    userBooks.CheckIn = (String)dr["check_in"];
                    userBooks.CheckOut = (String)dr["check_out"];
                    userBooks.Vaild = (String)dr["vaild"];
                    userBooks.Price = Convert.ToInt16(dr["price"]);
                    userBooks.Date_register = (String)dr["date_register"];


                    userBooksList.Add(userBooks);
                }
                con.Close();
                return userBooksList;

            
        }

        private SqlCommand CreateGetUser_Books(SqlConnection con, String email)
        {

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@email", email);

            command.CommandText = "SPGetBooksByEmail";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }






        //--Create User--------------------------------------------
        public int InsertUser(User user)
            {
            SqlConnection con = Connect("DBConnectionString");

            // Create Command
            SqlCommand command = CreateInsertCommand_User(con, user);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection

            con.Close();

                return numAffected;
            }

        private SqlCommand CreateInsertCommand_User(SqlConnection con, User user)
        {
            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@user", user.Username); 
            command.Parameters.AddWithValue("@password", user.Password);
            command.Parameters.AddWithValue("@email", user.Email);
            command.Parameters.AddWithValue("@date_register", user.Date_register);
            command.Parameters.AddWithValue("@totalPrice", user.TotalPrice);

            command.CommandText = "spInsertUser";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }


        //-------Get all users-----------
        public List<User> GetUsers()
        {
            SqlConnection con = null;
            List<User> userList = new List<User>();

            try
            {
                con = Connect("DBConnectionString");//create connect to the database using the the connection string in web config file

                String selectSTR = "SELECT * FROM Users";
                SqlCommand cmd = new SqlCommand(selectSTR, con);

                //get a reader
                SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end


                while (dr.Read())
                {
                    //read till the end of the data per row
                    User user = new User();

                    user.Username = (String)dr["user"];
                    user.Password = (String)dr["password"];
                    user.Email = (String)dr["email"];
                    user.Date_register = (String)dr["date_register"];
                    user.TotalPrice = Convert.ToInt16(dr["totalPrice"]);

                    userList.Add(user);
                }
                return userList;
            }
            catch (Exception ex)
            {
                //write to log
                throw (ex);
            }
            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }
        }


        //-------------Get User by Email----------------

        public User GetUser_ByEmail(String email)
        {

            SqlConnection con = Connect("DBConnectionString");           

            SqlCommand cmd = CreateGetUser(con, email);

            //get a reader
            SqlDataReader dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);// CommandBehavior.CloseConnection: the connection will be closed after reading has reached the end

            User user = null;
            while (dr.Read())
            {
                string username = dr["user"].ToString();
                string password = dr["password"].ToString();
                string email1 = dr["email"].ToString();
                string date_register = dr["date_register"].ToString();
                int totalPrice = Convert.ToInt16(dr["totalPrice"]);

                user = new User(username, password, email1, date_register, totalPrice);

                
            }
            con.Close();
            return user;


        }

        private SqlCommand CreateGetUser(SqlConnection con, String email)
        {

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@email", email);

            command.CommandText = "SPGetUserByEmail";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }



        //-----UPDATE THE VAILD --> WHEN USER CANCEL  --------

        public int ChangeVaild(int orderId, string vaild)
        {
            SqlConnection con = Connect("DBConnectionString");

            string currentVaild = vaild;

            // Create Command
            SqlCommand command = CreateChangeVaild(con, orderId, currentVaild);

            // Execute
            int numAffected = command.ExecuteNonQuery();

            // Close Connection
            con.Close();

            return numAffected;

        }
        private SqlCommand CreateChangeVaild(SqlConnection con, int order_id, string vaild)
        {

            SqlCommand command = new SqlCommand();

            command.Parameters.AddWithValue("@order_id", order_id);
            command.Parameters.AddWithValue("@vaild", vaild);

            command.CommandText = "SPChangeVaild";
            command.Connection = con;
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandTimeout = 10; // in seconds

            return command;
        }






        //---------------------------------------------------------------------------------
        // Read Users by email using a DataSet
        //---------------------------------------------------------------------------------

        public DBservices readUserBy_Email(string email)
        {
            SqlConnection con = null;
            try
            {
                con = Connect("DBConnectionString");
                da = new SqlDataAdapter("select * from Users where email= '" + email +"'", con); 
                SqlCommandBuilder builder = new SqlCommandBuilder(da);
                DataSet ds = new DataSet();
                da.Fill(ds);
                dt = ds.Tables[0];
            }

            catch (Exception ex)
            {
                // write errors to log file
                // try to handle the error
                throw ex;
            }

            finally
            {
                if (con != null)
                {
                    con.Close();
                }
            }

            return this;

        }

        public void update()
        {
            da.Update(dt);
        }




        //---Connection func--------------------------------------------------------------
        public SqlConnection Connect(String conString)
        {
            // read the connection string from the web.config file
            string connectionString = WebConfigurationManager.ConnectionStrings[conString].ConnectionString;

            // create the connection to the db
            SqlConnection con = new SqlConnection(connectionString);

            // open the database connection
            con.Open();

            return con;

        }

        
    }
}