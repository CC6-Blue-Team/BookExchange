using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Web;



namespace BookDonation.DB
{
    public class BookDonationDb : DbContext
    {
        public BookDonationDb() : base("name=BookDonationDb")
        {
        }

        public DbSet<Books> Books { get; set; }

        public DbSet<Exchange> Exchange { get; set; }

        public DbSet<Genres> Genres { get; set; }

        public DbSet<Actions> Actions { get; set; }

        public DbSet<Authors> Authors { get; set; }
    }
}
