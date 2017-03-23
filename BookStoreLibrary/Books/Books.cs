using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreLibrary.Books
{
    public class Books
    {
        public int BookID { get; set; }        
        public string Title { get; set; }
        public string Author { get; set; }
        public float Price { get; set; }
        public int CategoryID { get; set; }
        public int NoOfBooks { get; set; }
        public string image { get; set; }

        
    }
}
