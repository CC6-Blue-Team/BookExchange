namespace BookDonation.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenAuthActFields : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Genres", "Genre", c => c.String());
            CreateIndex("dbo.Books", "GenreId");
            CreateIndex("dbo.Books", "AuthorId");
            AddForeignKey("dbo.Books", "AuthorId", "dbo.Authors", "AuthorId", cascadeDelete: true);
            AddForeignKey("dbo.Books", "GenreId", "dbo.Genres", "GenreId", cascadeDelete: true);
            DropColumn("dbo.Books", "QtyReserved");
            DropColumn("dbo.Exchanges", "ActionId");
            DropColumn("dbo.Genres", "Name");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Genres", "Name", c => c.String());
            AddColumn("dbo.Exchanges", "ActionId", c => c.Int(nullable: false));
            AddColumn("dbo.Books", "QtyReserved", c => c.Byte(nullable: false));
            DropForeignKey("dbo.Books", "GenreId", "dbo.Genres");
            DropForeignKey("dbo.Books", "AuthorId", "dbo.Authors");
            DropIndex("dbo.Books", new[] { "AuthorId" });
            DropIndex("dbo.Books", new[] { "GenreId" });
            DropColumn("dbo.Genres", "Genre");
        }
    }
}
