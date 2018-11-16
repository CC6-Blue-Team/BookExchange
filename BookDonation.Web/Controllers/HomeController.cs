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

        // GET: Books/Cart/
        public ActionResult DonateCart(int? id)
        {
            Books myBooks = db.Books.Find(id);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            


            if (myBooks == null)
            {
                return HttpNotFound();
            }

            //ViewBag.tax = movies.Price * 0.08;
            //CalcTax ct = new CalcTax();
            DonateBookVM donateCart = new DonateBookVM();

            donateCart.Title = myBooks.Title;
            donateCart.ISBN = myBooks.ISBN;
            donateCart.QtyAvailable = myBooks.QtyAvailable;
            //donateCart.QtyAvailable = ct.GetTax(donateCart.Price);
            //donateCart.Total = myCart.Price + (ct.GetTax(donateCart.Price));

            //ViewBag.Total = myCart.Total;
            //ViewBag.Tax = myCart.Tax;

            return View(donateCart);

        }

        // GET: Books/Donate
        public ActionResult Donate()
        {
            ViewBag.GenreId = new SelectList(db.Genres, "GenreId", "Genre");
            ViewBag.AuthorId = new SelectList(db.Authors, "AuthorId", "Name");
            ////DonateBookVM donateCart = new DonateBookVM();
            //var books = new Books();
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
                return RedirectToAction("DonateCart");
            }

            //ViewBag.GenreId = new SelectList(db.Genre, "Id", "Type", books.Genre);
            return View(books);
        }



        //// GET: Books/donate
        //public ActionResult Donate()
        //{
        //    var myBooks = new Books();
        //    return View(myBooks);
        //}


        //// POST: Products/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        ////public ActionResult Create([Bind(Include = "ID,Sku,Name,AlertThreshHold,Size,Quantity")] Database.Models.ProductAddVM product)
        //public ActionResult Donate([Bind(Include = "ID,Title,ISBN,Image,QtyAvailable,GenreId,AuthorId")] Books myBooks)
        //{
        //    ///*ModelState["ApplicationUser"].Errors.Clear();  /*//Required since ApplicationUser is NOT populated by the user in the view.

        //    if (!ModelState.IsValid)
        //        return View();

        //    if (myBooks.Title == null)
        //        return View(myBooks);

        //    //determine if a Product already exists with the same Title
        //    bool BookExists = false;

        //    ViewBag.message = "";

        //    string findTitle = "";
        //    findTitle = myBooks.Title.Trim().ToUpper();

        //    //Products have to have a unique Sku
        //    if (findTitle == "N/A" || findTitle == "NA" || findTitle == "N A")
        //    {
        //        ViewBag.message = "Input a Valid BookTitle - don't use N/A or NA or N A";
        //        return View();
        //    }

        //    int pID = 0;
        //    BookDonationDb db = new BookDonationDb();
        //    var results = BookDbQueries.BookRequestFromInventory(db);
        //    findTitle = myBooks.Title.Trim().ToUpper();
        //    foreach (var item in results)
        //    {

        //        if (findTitle == item.Title.Trim().ToUpper())
        //            BookExists = true;
        //        if (BookExists)
        //        {
        //            pID = item.ID;
        //            break;
        //        }


        //        var book = new Books
        //        {
        //            Title = myBooks.Title,
        //            ISBN = myBooks.ISBN,
        //            QtyAvailable = myBooks.QtyAvailable,
        //        };



        //                db.Books.Add(book);
        //                db.SaveChanges();
        //    }

        //    return View();
        //}



        public ActionResult Reserve()
        {
            ViewBag.Message = "";

            return View();
        }
   }
}

