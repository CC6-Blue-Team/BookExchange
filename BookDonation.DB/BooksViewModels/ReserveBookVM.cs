using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB.BooksViewModels
{
    public class ReserveBookVM
    {
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Title is required")]
        public string Title { get; set; }
        
        [StringLength(200, MinimumLength = 5, ErrorMessage = "Author name is required")]
        public string Author { get; set; }
        public string ISBN { get; set; }
        public byte QtyAvailable { get; set; }
        public byte[] Image { get; set; }
    }
}
