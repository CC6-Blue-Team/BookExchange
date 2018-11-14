using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookDonation.Web.BooksViewModels;
using BookDonation.Web; 





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


        // GET: Books/donate
        public ActionResult Donate()
        {
            var pm = new DonateBookVM();
            return View(pm);
        }


        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "ID,Sku,Name,AlertThreshHold,Size,Quantity")] Database.Models.ProductAddVM product)
        public ActionResult Create([Bind(Include = "Author,BookTitle,ISBN,Genre,Quantity")] DonateBookVM donateBook)
        {
            ///*ModelState["ApplicationUser"].Errors.Clear();  /*//Required since ApplicationUser is NOT populated by the user in the view.

            if (!ModelState.IsValid)
                return View(donateBook);
            if (donateBook.Title == null)
                return View(donateBook);
            //determine if a Product already exists with the same Title
            bool ProductExists = false;
            ViewBag.message = "";
            string findTitle = "";
            findTitle = donateBook.Title.Trim().ToUpper();
            //Products have to have a unique Sku
            if (findTitle == "N/A" || findTitle == "NA" || findTitle == "N A")
            {
                ViewBag.message = "Input a Valid BookTitle - don't use N/A or NA or N A";
                return View(donateBook);
            }

            int pID = 0;
            var results = BookDbQueries.BooksInventory();
            findTitle = donateBook.Title.Trim().ToUpper();
            foreach (var item in results)
            {
                if (findTitle == item.Title.Trim().ToUpper())
                    ProductExists = true;
                if (ProductExists)
                {
                    pID = item.ID;
                    break;
                }
            };
        }

        public ActionResult Reserve()
        {
            ViewBag.Message = "";

            return View();
        }
    }
}
