using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB.BooksViewModels
{
    public class RequestBookVM
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
    }
}