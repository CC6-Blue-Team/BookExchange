using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB.BooksViewModels
{
    public class DonateBookVM
    {
        [Required]
        public int ID { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3,
            ErrorMessage = "Title is required")]
        public string Title { get; set; }
        

        [StringLength(200, MinimumLength = 5,
            ErrorMessage = "Author name is required")]
        public string Author { get; set; }

        [Range(0, int.MaxValue,
            ErrorMessage = "ISBN is required")]
        public string ISBN { get; set; }

        [Range(1, int.MaxValue,
            ErrorMessage = "Please enter a Quantity value 1 or greater")]
        public byte QtyAvailable { get; set; }

        public IEnumerable<SelectListItem> Genre
        {
            get
            {
                return new[]
                    {
                     new SelectListItem { Value = "", Text = "" },
                     new SelectListItem { Value = "Fiction", Text = "Fiction" },
                     new SelectListItem { Value = "Non-Fiction", Text = "Non-Fiction" },
                     new SelectListItem { Value = "Children", Text = "Children" },
                };
            }
        }
    }
}