using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using BookStoreLibrary.Books;

namespace BookStoreLibrary.OrderDetails
{
    public class Cart
    {
        [Key]
        public string CartId { get; set; }
        public int BookId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        //public virtual Books Books { get; set; }
    }
}
