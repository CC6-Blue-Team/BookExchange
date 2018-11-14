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

        public class DueDate
        {
            DateTime GetDueDate(double workday)
            {
                DateTime dueDate = DateTime.Now.AddDays(workday);
                if (Convert.ToString(dueDate.DayOfWeek).Equals("Saturday"))
                {
                    dueDate = dueDate.AddDays(2);
                }
                else if (Convert.ToString(dueDate.DayOfWeek).Equals("Sunday"))
                {
                    dueDate = dueDate.AddDays(1);
                }

                return dueDate;
            }
        }
    }
}
