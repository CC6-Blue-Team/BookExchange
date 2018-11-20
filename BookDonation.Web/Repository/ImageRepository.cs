using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using BookDonation.DB;
using BookDonation.Web;
using BookDonation.DB.BooksViewModels;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookDonation.Web.Controllers
{
    public class Repository
    {
        private readonly BookDonationDb db = new BookDonationDb();
        public int UploadImageInDataBase(HttpPostedFileBase file, DonateBookVM donateBookVM)
        {
            donateBookVM.Image = ConvertToBytes(file);


            var books = new Books
            {
                Image = donateBookVM.Image,
            };



            int i = db.SaveChanges();

            if (i == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }

        }

        public byte[] ConvertToBytes(HttpPostedFileBase image)
        {
            byte[] imageBytes = null;
            BinaryReader reader = new BinaryReader(image.InputStream);
            imageBytes = reader.ReadBytes((int)image.ContentLength);
            return imageBytes;
        }
    }
}