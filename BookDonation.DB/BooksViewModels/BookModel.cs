using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
//using BookDonation.DBQueries; 
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Reflection;

namespace BookDonation.DB.BooksViewModels
{
    public class BookModel
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
        public virtual string Genre { get; set; }
        //from exchange models
        public virtual DateTime PickupDeadline { get; set; }
        public virtual DateTime ActionDate { get; set; }
        public virtual int BookId { get; set; }
        public virtual int ActionByUserId { get; set; }
        public virtual int ActionId { get; set; }
    }
}