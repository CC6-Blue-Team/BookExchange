//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using System.ComponentModel.DataAnnotations;

//namespace BookDonation.Web.BooksViewModels
//{
//    public class RequestBookVM
//    {
//        [Required]
//        [StringLength(50, MinimumLength = 3,
//           ErrorMessage = "Title is required")]
//        public string Title { get; set; }
//        //[Required] - not required so they can add inventory by only putting in the SKU
//        [StringLength(200, MinimumLength = 5,
//            ErrorMessage = "Author name is required")]
//        public string Author { get; set; }
//    }
//}