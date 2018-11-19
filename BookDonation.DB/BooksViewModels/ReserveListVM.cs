using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDonation.DB.BooksViewModels
{
    public class ReserveListVM
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public byte QtyAvailable { get; set; }
        public byte[] Image { get; set; }
    }
}
