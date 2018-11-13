using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDonation.Web.BooksViewModels;

namespace _1.BookDonation.Web.Controllers
{
    public class HomeController : Controller
    {
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
            ViewBag.Message = new SelectList(db.Books, "ID", "Title", "ISBN", "Image", "QtyAvailable", "GenreId", "AuthorId");
            return View();
        }

        // POST: Movies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,YearRelease,GenreID,Price")] Movies movies)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movies);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.GenreID = new SelectList(db.Genre, "ID", "Name", movies.GenreID);
            return View(movies);
        }



        public ActionResult Reserve()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}