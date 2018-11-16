using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Data;

namespace BookDonation.DB
{
    public class Exchange
    {
        public virtual int Id { get; set; }
        public virtual DateTime PickupDeadline { get; set; }
        public virtual DateTime ActionDate { get; set; }
        public virtual int BookId { get; set; }
        public virtual int ActionByUserId { get; set; }
        public virtual int ActionID { get; set; }
    }
}
