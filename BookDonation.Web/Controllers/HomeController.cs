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
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Donate()
        {
            ViewBag.Message = "";

            return View(new DonateBookVM());
        }

        public ActionResult Reserve()
        {
            ViewBag.Message = "";

            return View();
        }

        public ActionResult Request()
        {
            ViewBag.Message = "";

            return View();
        }

    }
}