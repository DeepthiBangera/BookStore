using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.OrderDetails
{
    class OrderRepository : IOrderRepository
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["DBConnectionString"].ConnectionString;
        //public void AddOrderDetails(OrderDetails o)
        //{
        //    SqlConnection connectionBook = new SqlConnection(connectionString);
        //    SqlCommand commandBook = new SqlCommand("INSERT INTO OrderDetails VALUES (@Quantity, @TotalAmount,  @OrderID, @BookID)", connectionBook);

        //    SqlParameter paramQuantity = new SqlParameter("@Quantity", o.Quantity);
        //    SqlParameter paramTotalAmount = new SqlParameter("@TotalAmount", o.TotalAmount);
        //    SqlParameter paramOrderID = new SqlParameter("@OrderID", o.OrderID);
        //    SqlParameter paramBookID = new SqlParameter("@BookID", o.BookID);

        //    commandBook.Parameters.Add(paramQuantity);
        //    commandBook.Parameters.Add(paramTotalAmount);
        //    commandBook.Parameters.Add(paramOrderID);
        //    commandBook.Parameters.Add(paramBookID);
            
        //    try
        //    {
        //        connectionBook.Open();
        //        commandBook.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        connectionBook.Close();
        //    }
        //}

        //public void DeleteOrderDetails(OrderDetails o)
        //{
        //    SqlConnection connectionBook = new SqlConnection(connectionString);
        //    SqlCommand commandBook = new SqlCommand("Delete from OrderDetails Where OrderDetailID=@OrderDetailID", connectionBook);
        //    SqlParameter paramID = new SqlParameter("@OrderDetailID", o.OrderDetailID);
        //    commandBook.Parameters.Add(paramID);

        //    try
        //    {
        //        connectionBook.Open();
        //        commandBook.ExecuteNonQuery();
        //    }
        //    catch (Exception e)
        //    {
        //        connectionBook.Close();
        //    }
        //}

        //public List<OrderDetails> GetOrderDetailsByID(int OrderDetailID)
        //{
        //    SqlConnection connectionBook = new SqlConnection(connectionString);
        //    SqlCommand commandBook = new SqlCommand("Select OrderDetailID, Quantity, TotalAmount, OrderID, BookID from OrderDetails where OrderDetailID=@OrderDetailID", connectionBook);
        //    SqlDataAdapter adapterBook = new SqlDataAdapter();
        //    adapterBook.SelectCommand = commandBook;
        //    SqlParameter paramID = new SqlParameter("@OrderDetailID", OrderDetailID);
        //    commandBook.Parameters.Add(paramID);
        //    DataSet ds = new DataSet();
        //    adapterBook.Fill(ds);
        //    OrderDetails book = new OrderDetails();
        //    DataRow dr = ds.Tables[0].Rows[0];
        //    book.OrderDetailID = int.Parse(dr["OrderDetailID"].ToString());
        //    book.Quantity =int.Parse(dr["Quantity"].ToString());
        //    book.TotalAmount = int.Parse(dr["TotalAmount"].ToString());
        //    book.OrderID = int.Parse(dr["OrderID"].ToString());
        //    book.BookID = int.Parse(dr["BookID"].ToString());
        //    return book;
        //}

        //public List<OrderDetails> GetAllOrderDetails(int OrderDetailID)
        //{
        //    SqlConnection connectionBook = new SqlConnection(connectionString);
        //    SqlCommand commandBook = new SqlCommand("Select OrderDetailID, Quantity, TotalAmount, OrderID, BookID from OrderDetails ", connectionBook);
        //    SqlDataAdapter adapterBook = new SqlDataAdapter();
        //    adapterBook.SelectCommand = commandBook;
        //    DataTable tableBook = new DataTable();
        //    adapterBook.Fill(tableBook);
        //    List<OrderDetails> bookList = new List<OrderDetails>();
        //    OrderDetails book;
        //    foreach (DataRow dr in tableBook.Rows)
        //    {
        //        book = new OrderDetails()
        //        {
        //             book.OrderDetailID = int.Parse(dr["OrderDetailID"].ToString()),
        //             book.Quantity =int.Parse(dr["Quantity"].ToString()),
        //             book.TotalAmount = int.Parse(dr["TotalAmount"].ToString()),
        //             book.OrderID = int.Parse(dr["OrderID"].ToString()),
        //             book.BookID = int.Parse(dr["BookID"].ToString())
        //        };
        //        bookList.Add(book);
        //    }
        //    return bookList;
        //}
    }
}
