
using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB
{
    public class Genres
    {
        [Key]
        public virtual int GenreId { get; set; }
        public virtual string Name { get; set; }
    }
}
