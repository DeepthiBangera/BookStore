using BookStoreLibrary.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/
        protected List<string> keywords = new List<string>();
        public ActionResult Index()
        {
            ViewBag.Message = false;
            return View();
        }

        /// <summary>
        /// Get value from view textbox and send to model
        /// </summary>
        /// <param name="txtValue"></param>
        /// <returns></returns>
        /// 
    
        public ActionResult GetBookByCategory()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetBookByCategory(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            List<Books> b = _GetRepository.GetBookByCategoryID(id);
            //List<Books> bookList = new List<Books>();
            //bookList = _GetRepository.GetAllBooks();
            return View("ListView", b);
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
        public ActionResult GetBookByName()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GetBookByName(string Title)
        {
            BookRepository _GetRepository = new BookRepository();
            Books b = _GetRepository.GetBookByName(Title);
            //List<Books> bookList = new List<Books>();
            //bookList = _GetRepository.GetAllBooks();
            return View("ListView", b);
        }
        public ActionResult Add()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Add(Books b)
        {
            BookRepository _AddRepository = new BookRepository();
            _AddRepository.AddBook(b);
            List<Books> bookList = new List<Books>();
            bookList = _AddRepository.GetAllBooks();
            return View("ListView", bookList);
        }
        public ActionResult ListView()
        {
            BookRepository _Repository = new BookRepository();
            List<Books> bookList = _Repository.GetAllBooks();
            return View(bookList);
        }
        public ActionResult Update(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            Books b = _GetRepository.GetBookByID(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Update(Books b)
        {
            BookRepository _UpdateRepository = new BookRepository();
            _UpdateRepository.UpdateBook(b);
            List<Books> bookList = new List<Books>();
            bookList = _UpdateRepository.GetAllBooks();
            return View("ListView", bookList);
        }

        public ActionResult Delete(int id)
        {
            BookRepository _GetRepository = new BookRepository();
            Books b = _GetRepository.GetBookByID(id);
            return View(b);
        }
        
        [HttpPost]
        public ActionResult Delete(Books b)
        {
            BookRepository _DeleteRepository = new BookRepository();
            _DeleteRepository.DeleteBook(b);
            List<Books> bookList = new List<Books>();
            bookList = _DeleteRepository.GetAllBooks();
            return View("ListView", bookList);
        }
        
    }
}
