using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDonation.Web.BooksViewModels;
using BookDonation.DB;


namespace _1.BookDonation.Web.Controllers
{
    public class HomeController : Controller
    {
        private BookDonationDb db = new BookDonationDb();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "BookBank6 is a book exchange website.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        // GET: Movies/Create
        public ActionResult Donate()
        {
            ViewBag.Message = new SelectList(db.Books, "Title", "ISBN", "Image", "QtyAvailable", "GenreId", "AuthorId");
            //(db.Books, "ID", "Title", "ISBN", "Image", "QtyAvailable", "GenreId", "AuthorId");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Title,ISBN,Image,QtyAvailable,GenreId,AuthorId")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genres, "ID", "Name", books.GenreId);
            return View(books);
        }



        public ActionResult Reserve()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}