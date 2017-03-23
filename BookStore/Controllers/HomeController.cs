using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookStoreLibrary.Books;
using BookStoreLibrary.Category;


namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        //public ActionResult Novel()
        //{
        //    // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}
        //public ActionResult Comic()
        //{
        //    // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}
        //public ActionResult Cooking()
        //{
        //    // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}
        //public ActionResult Philosophy()
        //{
        //    // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}

        //public ActionResult Index()
        //{
        //   // ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

        //    return View();
        //}

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        protected List<string> keywords = new List<string>();
        public ActionResult Index()
        {
            ViewBag.Message = false;
            CategoryRepository _GetRepository = new CategoryRepository();
            List<Category> b = _GetRepository.GetAllCategory();
            //List<Books> bookList = new List<Books>();
            //bookList = _GetRepository.GetAllBooks();
            return View(b);
            //return View();
        }
        [HttpPost]
        public ActionResult Index(string txtValue)
        {
            // Check length before for process
            if (txtValue.Length > 0)
            {
                // Turn user input to a list of keywords.
                string[] keywords = txtValue.Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                this.keywords = keywords.ToList();
                BookRepository dataAccess = new BookRepository();

                // call search method and passed generated keyword
                List<Books> list = dataAccess.Search(this.keywords);
                return View(list);
            }
            else
            {
                // If no keyword are entered than send error message to user
                ViewBag.Message = true;
                return View();
            }
        }

        //public ActionResult UserIndex()
        //{
        //    CategoryRepository _GetRepository = new CategoryRepository();
        //    List<Category> b = _GetRepository.GetAllCategory();
        //    //List<Books> bookList = new List<Books>();
        //    //bookList = _GetRepository.GetAllBooks();
        //    return View(b);
        //}
        public ActionResult ListView()
        {
            BookRepository _Repository = new BookRepository();
            List<Books> bookList = _Repository.GetAllBooks();
            return View(bookList);
        }

        public ActionResult BookView(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            List<Books> b = _GetRepository.GetBookByCategoryID(id);
            return View("ListView", b);
        }
    }
}
