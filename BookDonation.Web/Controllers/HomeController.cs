using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDonation.DB.BooksViewModels;
using BookDonation.DB;
using BookDonation.DBQueries;
using System.Net;

namespace _1.BookDonation.Web.Controllers
{
    public class HomeController : Controller
    {
        private BookDonationDb db = new BookDonationDb();
        private Books bks = new Books();
        private Authors auths = new Authors();


        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }


        // GET: Books/Donate
        public ActionResult Donate()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre");
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");

            return View();
        }

        // POST: Books/Donate
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Donate([Bind(Include = "Id,Title,ISBN, Image, QtyAvailable,GenreId,AuthorId")] Books books)
        {
            if (ModelState.IsValid)
            {
                db.Books.Add(books);
                db.SaveChanges();
                return RedirectToAction("DonateReceipt");
            }

            return View(books);
        }

        [HttpGet]
        public ActionResult DonateReceipt()
        {
            return View();
        }

            [HttpGet]
        public ActionResult Reserve()
        {
            var reserveListVM = new ReserveListVM();
            var content = db.Books.Select(bks => new
            {
                bks.Title,
                bks.ISBN,
                bks.authors,
                bks.QtyAvailable,
                bks.Image
            });

            List<ReserveListVM> reserveListedVM = content.Select(item => new ReserveListVM()
            {
                Title = item.Title,
                Image = item.Image,
                ISBN = item.ISBN,
                Author = item.authors.Name
            }).ToList();

            return View(reserveListedVM);
        }




   }
}

