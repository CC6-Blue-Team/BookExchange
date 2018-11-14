using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookDonation.DBQueries;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Text;
using BookDonation.Web.BooksViewModels;



namespace BookDonation.DBQueries
{
    public class BookDbQueries
    {


        // get all Gift Shop Inventories
        public static IEnumerable <BookModel> BooksInventory()
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();

                var results =
                              (from p in db.Books
                               join pinv in db.Authors on p.Id equals pinv.AuthorId
                               join ping in db.Genre on p.Id equals ping.GenreId
                              
                               orderby p.Title, pinv.Name, ping.Genre
                               select new BookModel
                               //BusinessVM is the same format as ProductInventory Model (class of ProductModel.cs)
                               //Can't use ProductInventory Model directory because
                               //it would create circular reference between Web and Business Projects.
                               //ProductsController writes data from BusinessVM to ProductInventory.
                               {
                                   ID = p.Id,
                                   Sku = p.Title,
                                   Name = pinv.Name,
                                   ISBN = p.ISBN,
                                   Image= p.Image,
                                   Genre = ping.Genre,
                                  
                               }).ToList();
                return (results);
            }
            catch (Exception ex)
            {

                throw (ex);
                //return (null);  
            }

        }



        //Get the Sum Quantity for all the Product Inventories for a Product
        public static int SumProductInventoryQuantityForId(int id)
        {
            try
            {
                ApplicationDbContext db = new ApplicationDbContext();

                var results =
                              (from p in db.Products
                                   //from pinv in db.ProductInventories
                               where (p.ID == id)
                               join pinv in db.ProductInventories on p.ID equals pinv.Product.ID
                               orderby p.SKU
                               select pinv);
                var sumOfQuantity = results.ToList().Select(pinv => pinv.Quantity).Sum();

                return sumOfQuantity;
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }
        //Sending the email
        public static bool SendEmail(string toEmail, string subject, string emailBody)
        {
            try
            {
                string senderEmail = ConfigurationManager.AppSettings["SenderEmail"].ToString();
                string senderPassword = ConfigurationManager.AppSettings["SenderPassword"].ToString();

                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(senderEmail, senderPassword);

                MailMessage mailMessage = new MailMessage(senderEmail, toEmail, subject, emailBody);
                mailMessage.IsBodyHtml = true;
                mailMessage.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(mailMessage);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
