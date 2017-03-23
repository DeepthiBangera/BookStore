using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Customer
{
    public class CustomerRepository : ICustomerRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public void AddCustomer(Customer c)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("INSERT INTO Customer VALUES (@Name, @Contact,  @Email, @Password)", connectionBook);

            SqlParameter paramName = new SqlParameter("@Name", c.Name);
            SqlParameter paramContact = new SqlParameter("@Contact", c.Contact);
            SqlParameter paramEmail = new SqlParameter("@Email", c.Email);
            SqlParameter paramPassword = new SqlParameter("@Password", c.Password);


            commandBook.Parameters.Add(paramName);
            commandBook.Parameters.Add(paramContact);
            commandBook.Parameters.Add(paramEmail);
            commandBook.Parameters.Add(paramPassword);

            try
            {
                connectionBook.Open();
                commandBook.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connectionBook.Close();
            }
        }
        public void AddCust(CustomerOrder c)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("INSERT INTO Customer VALUES (@Name, @Contact,  @Email)", connectionBook);

            SqlParameter paramName = new SqlParameter("@Name", c.Name);
            SqlParameter paramContact = new SqlParameter("@Contact", c.Number);
            //SqlParameter paramEmail = new SqlParameter("@Email", c.Email);
            SqlParameter paramEmail = new SqlParameter("@Email", c.Email);


            commandBook.Parameters.Add(paramName);
            commandBook.Parameters.Add(paramContact);
            //commandBook.Parameters.Add(paramEmail);
            commandBook.Parameters.Add(paramEmail);

            try
            {
                connectionBook.Open();
                commandBook.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                connectionBook.Close();
            }
        }
        public Customer GetCustomerByID(int CustomerID)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select Name, Contact,  Email, Password from Customer where CustomerID=@CustomerID", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramID = new SqlParameter("@CustomerID", CustomerID);
            commandBook.Parameters.Add(paramID);
            DataSet ds = new DataSet();
            adapterBook.Fill(ds);
            Customer book = new Customer();
            DataRow dr = ds.Tables[0].Rows[0];
            //book.BookID= int.Parse(dr["BookID"].ToString());
            book.Name = dr["Name"].ToString();
            book.Contact = int.Parse(dr["Contact"].ToString());
            book.Email = dr["Email"].ToString();
            book.Password = dr["Password"].ToString();
            return book;
        }
        public bool IsValid(string _username, string _password)
        {
     
                SqlConnection connectionBook = new SqlConnection(connectionString);
                string _sql = @"SELECT [Name] FROM [Customer] " +
                       @"WHERE [Name] = @u AND [Password] = @p";

               // string _sql = " SELECT [Name] FROM [Customer] WHERE [Name] = 'Deepthi' AND [Password] = 123456";
                //string sql="SELECT Name FROM Customer WHERE Name = @u AND Password = @p";
                var cmd = new SqlCommand(_sql, connectionBook);
                //cmd.Parameters.Add(new SqlParameter("@u", SqlDbType.NVarChar,)).Value = _username;
                //cmd.Parameters.Add(new SqlParameter("@p", SqlDbType.NVarChar)).Value = Helpers.SHA1.Encode(_password);
            cmd.Parameters.Add(new SqlParameter("@u",_username));
            cmd.Parameters.Add(new SqlParameter("@p",_password));
                connectionBook.Open();
                var reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return true;
                }
                else
                {
                    reader.Dispose();
                    cmd.Dispose();
                    return false;
                }
       

        }
    }
}

