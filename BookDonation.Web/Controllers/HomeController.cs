using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDonation.DB.BooksViewModels;
using BookDonation.DB;
using BookDonation.DBQueries;
using System.Net;
using System.Data.Entity;

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
                var rec = db.Books.Where(b => b.ISBN == books.ISBN).FirstOrDefault();

                if (rec != null)  //book exists
                {
                    rec.QtyAvailable -= books.QtyAvailable;
                    db.Entry(rec).State = EntityState.Modified;
                }
                else
                {
                    db.Books.Add(books);
                }
            }

            db.SaveChanges();

            ViewBag.AuthorName = db.Authors.Find(books.AuthorId).Name;
            ViewBag.GenreName = db.Genres.Find(books.GenreId).Genre;

            return View("DonateReceipt", books);
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
                    QtyAvailable = item.QtyAvailable,
                    Author = item.authors.Name
                }).ToList();
                return View(reserveListedVM);
            

        }

        // POST: Books/Reserve
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Reserve([Bind(Include = "Id,Title,ISBN, Image, QtyAvailable,GenreId,AuthorId")] Books books)
        {
            //if (ModelState.IsValid)
            //{
            //    var rec = db.Books.Where(b => b.ISBN == books.ISBN).FirstOrDefault();

            //    if (rec != null)  //book exists
            //    {
            //        rec.QtyAvailable -= books.QtyAvailable;
            //        db.Entry(rec).State = EntityState.Modified;
            //        db.SaveChanges();
            //    }
            //    else
            //    {

            //        return View("ReserveReceipt", books);

            //    }
            //}

            return View("ReserveReceipt", books);
        }

        [HttpGet]
        public ActionResult ReserveReceipt(string ISBN)
        {
            var rec = db.Books.Where(b => b.ISBN == ISBN).FirstOrDefault();

            if (rec != null && rec.QtyAvailable != 0)  //book exists
            {
                rec.QtyAvailable -= 1;
                db.Entry(rec).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = "You reservation is complete!  The pick up information is below.";
            }
            else
            {
                ViewBag.Message = "No copies exist for this book";
            }

            return View("ReserveReceipt");
        }
    }


}



