using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreLibrary.Books;
using BookStoreLibrary.Category;
using BookStoreLibrary.Customer;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        
        //
        // GET: /User/
        public ActionResult ListView()
        {
            BookRepository _Repository = new BookRepository();
            List<Books> bookList = _Repository.GetAllBooks();
            return View(bookList);
        }
        public ActionResult Index()
        {
            CategoryRepository _GetRepository = new CategoryRepository();
            List< Category> b = _GetRepository.GetAllCategory();
            //List<Books> bookList = new List<Books>();
            //bookList = _GetRepository.GetAllBooks();
            return View(b);
        }

        public ActionResult BookView(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            List<Books> b = _GetRepository.GetBookByCategoryID(id);
            return View("ListView", b);
        }
        //[HttpPost]
        //public ActionResult BookView(int id)
        //{
        //    BookRepository _GetRepository = new BookRepository();
        //    List<Books> b = _GetRepository.GetBookByCategoryID(id);
        //    List<Books> bookList = new List<Books>();
        //    bookList = _GetRepository.GetAllBooks();
        //    return View("ListView", b);
        //}
        public ActionResult ImageClick(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            Books b = _GetRepository.GetBookByID(id);
            return View(b);
        }
        
        public ActionResult Buy()
        {
            //CustomerRepository _CreateRepository = new CustomerRepository();
            //Customer bookList = _CreateRepository.GetCustomerByID(id);
            return View();
            //return View();
        }
        //[HttpPost]
        //public ActionResult Buy(CustomerOrder b)
        //{
        //    CustomerRepository _CreateRepository = new CustomerRepository();
        //    _CreateRepository.AddCust(b);
        //    Customer bookList = new Customer();

        //    //int id = (int)Session["CustomerID"];
        //    bookList = _CreateRepository.GetCustomerByID(1000);
        //    return View(bookList);
        //}
        [HttpGet]
        public ActionResult AddCart(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            Books b = _GetRepository.GetBookByID(id);
            Session["BookID"] = id;
            //var bookid=Session["BookID"];
            List<SelectListItem> items = new List<SelectListItem>();
            items.Add(new SelectListItem { Text = "1", Value = "0", Selected = true });
            items.Add(new SelectListItem { Text = "2", Value = "1" });
            items.Add(new SelectListItem { Text = "3", Value = "2" });
            items.Add(new SelectListItem { Text = "4", Value = "3" });
            items.Add(new SelectListItem { Text = "5", Value = "4" });

            ViewBag.MovieType = items;
            return View(b);
        }
        
        public ActionResult Order()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Order(string name)
        {
            ViewBag.Message = "You have pressed YES.";
            return View();
        }
        //[HttpPost]
        //public ActionResult Order(string customerId, IEnumerable<OrderedItems> Result)
        //{
        //    // save order to database
        //       return new ContentResult() { Content = "Order received" };
        //}
    }
}
