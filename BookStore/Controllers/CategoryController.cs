using System;
using BookStoreLibrary.Category;
using BookStoreLibrary.Books;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BookStore.Controllers
{
    public class CategoryController : Controller
    {
        //
        // GET: /Category/
        public ActionResult Subcategory(int id)
        {
            CategoryRepository _GetRepository = new CategoryRepository();
            Category b = _GetRepository.GetCategoryByID(id);
            return View(b);
        }
        public ActionResult CategoryView()
        {
            //BookRepository _AddRepository = new BookRepository();
            //List<Books> bookList = new List<Books>();
            //bookList = _AddRepository.GetBookByCategory(id);
            //ViewBag.bookList = bookList;
            //return View("ListView", bookList);
            return View();
    
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(Category b)
        {
            CategoryRepository _AddRepository = new CategoryRepository();
            _AddRepository.AddCategory(b);
            List<Category> bookList = new List<Category>();
            bookList = _AddRepository.GetAllCategory();
            return View("ListView", bookList);
        }
        public ActionResult ListView()
        {
            CategoryRepository _Repository = new CategoryRepository();
            List<Category> bookList = _Repository.GetAllCategory();
            return View(bookList);
        }
        public ActionResult Update(int id)
        {
            CategoryRepository _GetRepository = new CategoryRepository();
            Category b = _GetRepository.GetCategoryByID(id);
            return View(b);
        }
        [HttpPost]
        public ActionResult Update(Category b)
        {
            CategoryRepository _UpdateRepository = new CategoryRepository();
            _UpdateRepository.UpdateCategory(b);
            List<Category> bookList = new List<Category>();
            bookList = _UpdateRepository.GetAllCategory();
            return View("ListView", bookList);
        }

        public ActionResult Delete(int id)
        {
            CategoryRepository _GetRepository = new CategoryRepository();
            Category b = _GetRepository.GetCategoryByID(id);
            return View(b);
        }

        [HttpPost]
        public ActionResult Delete(Category b)
        {
            CategoryRepository _DeleteRepository = new CategoryRepository();
            _DeleteRepository.DeleteCategory(b);
            List<Category> bookList = new List<Category>();
            bookList = _DeleteRepository.GetAllCategory();
            return View("ListView", bookList);
        }

    }
}
