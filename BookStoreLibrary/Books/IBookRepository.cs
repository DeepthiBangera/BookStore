using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Books
{
    public interface IBookRepository
    {
        void AddBook(Books b);
        void DeleteBook(Books b);
        void UpdateBook(Books b);
        Books GetBookByID(int BookID);
        Books GetBookByName(string Title);
        List<Books> GetBookByAuthor(string Author);
        List<Books> GetBookByCategoryID(int CategoryID);
        List<Books> GetAllBooks();
        List<Books> Search(List<string> keywords);
        List<Books> QueryList(string cmdText);
        SqlCommand GenerateSqlCommand(string cmdText);
        Books ReadValue(SqlDataReader reader);
    }
}
