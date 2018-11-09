using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;

namespace BookDonation.DB
{
    public class Books
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string ISBN { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual byte QtyAvailable { get; set; }
        public virtual byte QtyReserved { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int AuthorId { get; set; }
    }
}
