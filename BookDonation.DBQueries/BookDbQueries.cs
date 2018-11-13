using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDonation.DBQueries;
using System.Data.Entity;
using BookDonation.DB;
using BookDonation.Web.BooksViewModels;



namespace BookDonation.DBQueries
{
    public class BookDbQueries
    {
        public static IEnumerable<RequestBookVM> BookRequestFromInventory()
        {
            try
            {
                BookDonationDb db = new BookDonationDb();

                var results =
                              (from e in db.Exchange
                               join b in db.Books on e.BookId equals b.Id
                               join a in db.Authors on b.AuthorId equals a.AuthorId
                               orderby b.Title, b.AuthorId
                               select new RequestBookVM
                               //Joining BookInvID in Exchange Table with Books Table and joining AspNetUsers table by Foreign key
                               // generating a RequestedBookId
                               {
                                   Title = b.Title,
                                   Author = a.Name,
                                   //GenreId = b.GenreId,
                                   //BookId = e.BookId,
                                   //ActionByUserId = e.ActionByUserId,

                               }).ToList();

                return results;
            }

            catch (Exception ex)
            {

                throw (ex);
            }
        }


        public static IEnumerable<ReserveBookVM> CheckReserveBooksInventory()
        {
            try
            {
                BookDonationDb db = new BookDonationDb();

                var results =
                              (from b in db.Books
                               join binv in db.Exchange on b.Id equals binv.BookId
                               join a in db.Authors on b.AuthorId equals a.AuthorId
                               orderby b.Title, b.AuthorId, binv.ActionDate, binv.PickupDeadline
                               select new ReserveBookVM
                           //Joining BookInvID in Exchange Table with Books Table and
                           // generating a Reserved BookId
                           {
                                   //ID = b.ID,
                                   Title = b.Title,
                                   Author = a.Name,
                                   //QtyAvailable = b.QtyAvailable,
                                   //QtyReserved = b.QtyReserved,
                                   //GenreId = b.GenreId,
                                   //PickupDeadline = binv.PickupDeadline,
                                   //ActionDate = binv.ActionDate,
                                   //BookInvId = binv.BookInvId,
                                   //ActionByUserId = binv.ActionByUserId,
                               }).ToList();

                return results;
            }
            catch (Exception ex)
            {

                throw (ex);
                //Calling the GetDueDate method
            }
        }
    }
}


