using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookDonation.Business
{
    public class Calculations
    {
        public byte AddOne(byte qtyAvail)
        {
            int TotAvail = Convert.ToInt32(qtyAvail) + 1;
            return qtyAvail = Convert.ToByte(TotAvail);
        }

        public byte MinusOne(byte qtyAvail)
        {
            int TotAvail = Convert.ToInt32(qtyAvail) - 1;
            return qtyAvail = Convert.ToByte(TotAvail);
        }
    }
}
