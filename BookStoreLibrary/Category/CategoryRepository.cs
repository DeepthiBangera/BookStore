using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Category
{
    public class CategoryRepository:ICategoryRepository
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        public void AddCategory(Category b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("INSERT INTO Category VALUES (@CategoryName)", connectionBook);

            SqlParameter paramCategoryName = new SqlParameter("@CategoryName", b.CategoryName);

            commandBook.Parameters.Add(paramCategoryName);

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

        public void DeleteCategory(Category b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Delete from Category Where CategoryID=@CategoryID", connectionBook);
            SqlParameter paramID = new SqlParameter("@CategoryID", b.CategoryID);
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

        public List<Category> GetAllCategory()
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select CategoryID,CategoryName from Category", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            DataTable tableBook = new DataTable();
            adapterBook.Fill(tableBook);
            List<Category> bookList = new List<Category>();
            Category book;
            foreach (DataRow bookReader in tableBook.Rows)
            {
                book = new Category()
                {
                    CategoryID = int.Parse(bookReader["CategoryID"].ToString()),
                    CategoryName = bookReader["CategoryName"].ToString()
                };
                bookList.Add(book);
            }
            return bookList;
        }


        public void UpdateCategory(Category b)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Update Category set CategoryName=@CategoryName Where CategoryID=@CategoryID", connectionBook);
            SqlParameter paramID = new SqlParameter("@CategoryName", b.CategoryName);
            SqlParameter paramCategoryID = new SqlParameter("@CategoryID", b.CategoryID);
            
            commandBook.Parameters.Add(paramID);
            commandBook.Parameters.Add(paramCategoryID);

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

        public Category GetCategoryByID(int CategoryID)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select CategoryID,CategoryName from Category where CategoryID=@CategoryID", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramID = new SqlParameter("@CategoryID", CategoryID);
            commandBook.Parameters.Add(paramID);
            DataSet ds = new DataSet();
            adapterBook.Fill(ds);
            Category book = new Category();
            DataRow dr = ds.Tables[0].Rows[0];
            book.CategoryID = int.Parse(dr["CategoryID"].ToString());
            book.CategoryName = dr["CategoryName"].ToString();
            return book;
        }
        public List<Category> GetCategory(string Category)
        {
            SqlConnection connectionBook = new SqlConnection(connectionString);
            SqlCommand commandBook = new SqlCommand("Select CategoryID, CategoryName from Category where CategoryName=@category", connectionBook);
            SqlDataAdapter adapterBook = new SqlDataAdapter();
            adapterBook.SelectCommand = commandBook;
            SqlParameter paramCategory = new SqlParameter("@category", Category);
            commandBook.Parameters.Add(paramCategory);
            DataTable tableBook = new DataTable();
            adapterBook.Fill(tableBook);
            List<Category> bookList = new List<Category>();
            Category category;
            foreach (DataRow bookReader in tableBook.Rows)
            {
                category = new Category()
                {
                    CategoryID = int.Parse(bookReader["CategoryID"].ToString()),
                    CategoryName = bookReader["CategoryName"].ToString()
                };
                bookList.Add(category);
            }
            return bookList;
        }
    }
}
