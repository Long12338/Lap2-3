using ChiemHoangLong.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace lab1.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public String HelloTeacher(String university)
        {
            return "Chiêm Hoàng Long - university" + university;
        }

        public ActionResult ListBooks()
        {
            var books = new List<String>();
            books.Add ("HTML5&CSS the compelete manual - author name book 1");
            books.Add ("HTML5&CSS responsive web - author name book 2");
            books.Add ("professional ASP.NET MVC5 - author name book 3");
            ViewBag.Books = books;
            return View();
        }
        public ActionResult ListBookModel()
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual" ," author name book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web","author name book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5","author name book 3", "/Content/Images/book3cover.jpg"));
            return View(books);
        }
        [HttpPost, ActionName("EditBook ")]
        [ValidateAntiForgeryToken]
        public ActionResult EditBook(int id)
        {
            var books = new List<Book>();
            books.Add(new Book(1, "HTML5&CSS the compelete manual", " author name book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web", "author name book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5", "author name book 3", "/Content/Images/book3cover.jpg"));
            Book book = new Book();
            foreach (Book b in books)
            {
                if (b.Id == id)
                {
                    book = b;
                    break;
                }
            }
            if (book == null)
            {
                return HttpNotFound();
            }


            return View(book);
        }
        

        public ActionResult CreateBook()
        {
            return View();
        }
        public ActionResult Contact([Bind(Include = "Id, Title, Author, ImageCover")] Book book)
        {
            var books = new List<Book>();
            //Sach mac dinh;
            books.Add(new Book(1, "HTML5&CSS the compelete manual", " author name book 1", "/Content/Images/book1cover.jpg"));
            books.Add(new Book(2, "HTML5&CSS responsive web", "author name book 2", "/Content/Images/book2cover.jpg"));
            books.Add(new Book(3, "professional ASP.NET MVC5", "author name book 3", "/Content/Images/book3cover.jpg"));
            return View("ListBookModel", books);
        }

        private void NewMethod(Book book, List<Book> books)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    //them moi sach;
                    books.Add(book);
                }
            }
            catch (RetryLimitExceededException)
            {
                ModelState.AddModelError("", "Error save data");

            }
        }
    }
}