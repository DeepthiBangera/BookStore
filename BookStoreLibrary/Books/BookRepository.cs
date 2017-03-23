using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace BookStoreLibrary.Books
{
    public class BookRepository : IBookRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public void AddBook(Books b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("INSERT INTO Books VALUES (@Title, @Author,  @Price, @CategoryID, @NoOfBooks,@image)", connectionBook);
            
            SqlParameter paramName = new SqlParameter("@Title", b.Title);
            SqlParameter paramAuthor = new SqlParameter("@Author", b.Author);
            SqlParameter paramCategoryID = new SqlParameter("@CategoryID", b.CategoryID);
            SqlParameter paramPrice = new SqlParameter("@Price", b.Price);
            SqlParameter paramNoOfBooks = new SqlParameter("@NoOfBooks", b.NoOfBooks);
            SqlParameter paramimage = new SqlParameter("@image", b.image);
                
            commandBook.Parameters.Add(paramName);
            commandBook.Parameters.Add(paramAuthor);
            commandBook.Parameters.Add(paramCategoryID);
            commandBook.Parameters.Add(paramPrice);
            commandBook.Parameters.Add(paramNoOfBooks);
            commandBook.Parameters.Add(paramimage);

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

        public void DeleteBook(Books b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Delete from Books Where BookID=@BookID", connectionBook);
            SqlParameter paramID = new SqlParameter("@BookID", b.BookID);
            commandBook.Parameters.Add(paramID);

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

        public void UpdateBook(Books b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Update Books set Title=@Title, Author=@Author, Price=@Price, CategoryID=@CategoryID, NoOfBooks=@NoOfBooks,image=@image Where BookID=@BookID", connectionBook);
            SqlParameter paramID = new SqlParameter("@BookID", b.BookID);
            SqlParameter paramName = new SqlParameter("@Title", b.Title);
            SqlParameter paramAuthor = new SqlParameter("@Author", b.Author);
            SqlParameter paramPrice = new SqlParameter("@Price", b.Price);
            SqlParameter paramCategoryID = new SqlParameter("@CategoryID", b.CategoryID);
            SqlParameter paramNoOfBooks = new SqlParameter("@NoOfBooks", b.NoOfBooks);
            SqlParameter paramimage = new SqlParameter("@image", b.image);
            commandBook.Parameters.Add(paramNoOfBooks);
            commandBook.Parameters.Add(paramID);
            commandBook.Parameters.Add(paramName);
            commandBook.Parameters.Add(paramAuthor);
            commandBook.Parameters.Add(paramCategoryID);
            commandBook.Parameters.Add(paramPrice);
            commandBook.Parameters.Add(paramimage);

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

        public Books GetBookByID(int BookID)
        {   
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select Title,Author,Price, image from Books where BookID=@BookID", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramID = new SqlParameter("@BookID", BookID);
            commandBook.Parameters.Add(paramID);
            DataSet ds = new DataSet();
            adapterBook.Fill(ds);
            Books book = new Books();
            DataRow dr = ds.Tables[0].Rows[0];
            //book.BookID= int.Parse(dr["BookID"].ToString());
            book.Title = dr["Title"].ToString();
            book.Author = dr["Author"].ToString();
            book.Price = int.Parse(dr["Price"].ToString());
            //book.CategoryID = int.Parse(dr["CategoryID"].ToString());
            //book.NoOfBooks = int.Parse(dr["NoOfBooks"].ToString());
            book.image = dr["image"].ToString();
            return book;
        }

        public Books GetBookByName(string Title)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select BookID,Title,Author,Price,CategoryID,NoOfBooks,image from Books where Title=@Title", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramTitle = new SqlParameter("@Title", Title);
            commandBook.Parameters.Add(paramTitle);
            DataSet ds = new DataSet();
            adapterBook.Fill(ds);
            Books book = new Books();
            DataRow dr = ds.Tables[0].Rows[0];
            book.BookID = int.Parse(dr["BookID"].ToString());
            book.Title = dr["Title"].ToString();
            book.Author = dr["Author"].ToString();
            book.Price = int.Parse(dr["Price"].ToString());
            book.CategoryID = int.Parse(dr["CategoryID"].ToString());
            book.NoOfBooks = int.Parse(dr["NoOfBooks"].ToString());
            book.image = dr["image"].ToString();
            return book;
        }

        public List<Books> GetBookByAuthor(string Author)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select BookID,Title,Author,Price,CategoryID,NoOfBooks,image from Books where Author=@Author", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramAuthor = new SqlParameter("@Author", Author);
            commandBook.Parameters.Add(paramAuthor);
            DataTable tableBook = new DataTable();
            adapterBook.Fill(tableBook);
            List<Books> bookList = new List<Books>();
            Books book;
            foreach (DataRow bookReader in tableBook.Rows)
            {
                book = new Books()
                {
                    BookID = int.Parse(bookReader["BookID"].ToString()),
                    Title = bookReader["Title"].ToString(),
                    Author = bookReader["Author"].ToString(),
                    Price = float.Parse(bookReader["Price"].ToString()),
                    CategoryID = int.Parse(bookReader["CategoryID"].ToString()),
                    NoOfBooks = int.Parse(bookReader["NoOfBooks"].ToString()),
                    image = bookReader["image"].ToString()
                };
                bookList.Add(book);
            }
            return bookList;
        }

        public List<Books> GetBookByCategoryID(int CategoryID)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select BookID,Title,Author,Price,CategoryID,NoOfBooks,image from Books where CategoryID=@CategoryID", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramCategoryID = new SqlParameter("@CategoryID", CategoryID);
            commandBook.Parameters.Add(paramCategoryID);
            DataTable tableBook = new DataTable();
            adapterBook.Fill(tableBook);
            List<Books> bookList = new List<Books>();
            Books book;
            foreach (DataRow bookReader in tableBook.Rows)
            {
                book = new Books()
                {
                    BookID = int.Parse(bookReader["BookID"].ToString()),
                    Title = bookReader["Title"].ToString(),
                    Author = bookReader["Author"].ToString(),
                    Price = float.Parse(bookReader["Price"].ToString()),
                    CategoryID = int.Parse(bookReader["CategoryID"].ToString()),
                    NoOfBooks = int.Parse(bookReader["NoOfBooks"].ToString()),
                    image = bookReader["image"].ToString()
                };
                bookList.Add(book);
            }
            return bookList;
        }

        

        public List<Books> GetAllBooks()
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select BookID,Title,Author,Price,CategoryID,NoOfBooks,image from Books", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            DataTable tableBook = new DataTable();
            adapterBook.Fill(tableBook);
            List<Books> bookList = new List<Books>();
            Books book;
            foreach (DataRow bookReader in tableBook.Rows)
            {
                book = new Books()
                {
                    BookID = int.Parse(bookReader["BookID"].ToString()),
                    Title = bookReader["Title"].ToString(),
                    Author = bookReader["Author"].ToString(),
                    Price = float.Parse(bookReader["Price"].ToString()),
                    CategoryID = int.Parse(bookReader["CategoryID"].ToString()),
                    NoOfBooks = int.Parse(bookReader["NoOfBooks"].ToString()),
                    image = bookReader["image"].ToString()
                };
                bookList.Add(book);
            }
            return bookList;
        }
    
            public List<Books> Search(List<string> keywords)
            {
                // Generate a complex Sql command.
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append("select * from [Books] where ");
                foreach (string item in keywords)
                {
                    sqlBuilder.AppendFormat("([Title] like '%{0}%' or [Price] like '%{0}%' or [Author] like '%{0}%' or [CategoryID] like '%{0}%') and ", item);
                }

                // Remove unnecessary string " and " at the end of the command.
                string sql = sqlBuilder.ToString(0, sqlBuilder.Length - 5);

                return QueryList(sql);
            }
  
           
            
            public List<Books> QueryList(string cmdText)
            {
                List<Books> ctn = new List<Books>();

                SqlCommand cmd = GenerateSqlCommand(cmdText);
                using (cmd.Connection)
                {
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Transform records to a list.
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            ctn.Add(ReadValue(reader));
                        }
                    }
                }
                return ctn;
            }

            public SqlCommand GenerateSqlCommand(string cmdText)
            {
                // Read Connection String from web.config file.
                SqlConnection connectionBook = new SqlConnection(connectionString);
                //SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString);
                SqlCommand cmd = new SqlCommand(cmdText, connectionBook);
                cmd.Connection.Open();
                return cmd;
            }

            public Books ReadValue(SqlDataReader reader)
            {
                Books obj = new Books();

                obj.BookID = (int)reader["BookID"];
                obj.Title = (string)reader["Title"];
                obj.Author = (string)reader["Author"];
                obj.Price = float.Parse(reader["Price"].ToString());
                obj.CategoryID = (int)reader["CategoryID"];
                obj.NoOfBooks = (int)reader["NoOfBooks"];
                return obj;
            }
    }
}
