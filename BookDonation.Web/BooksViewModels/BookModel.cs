using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BookDonation.DB;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Reflection;

namespace BookDonation.Web.BooksViewModels
{
    public class BookInventoryModel
    {
        //from booksmodel
        public virtual int Id { get; set; }
        public virtual string Title { get; set; }
        public virtual string ISBN { get; set; }
        public virtual byte[] Image { get; set; }
        public virtual byte QtyAvailable { get; set; }
        // public virtual byte QtyReserved { get; set; }
        public virtual int GenreId { get; set; }
        public virtual int AuthorId { get; set; }
        //from author models
        public virtual string Name { get; set; }
        //from genre models
        public virtual int GenreId { get; set; }
        public virtual string Genre { get; set; }


    }
        public string InactiveStatus
    {
        get
        {
            var listProperties = IsDeleted;

            if (IsDeleted)
            {
                return "Discontinued";
            }
            else
            {
                return "Active";
            }
        }
    }

}
public class UpdateBookInventory
    {
        public string Name { get; set; }
        public int Quantity { get; set; }
        public int ID { get; set; }
        public int PInventoryID { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class BookModel
    {
        public List<BookInventoryModel> BInventoryList { get; set; }

        //sizes for Create View dropdown list
        public IEnumerable<SelectListItem> Genre
        {
            get
            {
                return new[]
                {
                     new SelectListItem { Value = "Fiction", Text = "Fiction" },
                     new SelectListItem { Value = "Non-Fiction", Text = "Non-Fiction" },
                     new SelectListItem { Value = "Children", Text = "Children" },
                     
                 };
            }
        }
    }
}