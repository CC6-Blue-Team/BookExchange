namespace BookDonation.DB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BookDonation.DB;

    internal sealed class Configuration : DbMigrationsConfiguration<BookDonation.DB.BookDonationDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(BookDonation.DB.BookDonationDb context)
        {
            context.Authors.AddOrUpdate(x => x.AuthorId,
                new Authors() { AuthorId = 1, Name = "Carolyn Queen"},
                new Authors() { AuthorId = 2, Name = "William Shakespeare" },
                new Authors() { AuthorId = 3, Name = "Agatha Criste" },
                new Authors() { AuthorId = 4, Name = "Barbara Cartland" },
                new Authors() { AuthorId = 5, Name = "Stephen King" },
                new Authors() { AuthorId = 6, Name = "Dale Carnegie" }
            );

            context.Genres.AddOrUpdate(x => x.GenreId,
                new Genres() { GenreId = 1, Genre = "Romance"},
                new Genres() { GenreId = 2, Genre = "Mystery"},
                new Genres() { GenreId = 3, Genre = "Drama"},
                new Genres() { GenreId = 4, Genre = "Fiction"},
                new Genres() { GenreId = 5, Genre = "Non-Fiction"},
                new Genres() { GenreId = 6, Genre = "Children"}
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
