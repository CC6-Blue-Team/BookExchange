namespace BookDonation.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Actions",
                c => new
                    {
                        ActionId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.ActionId);
            
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        AuthorId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.AuthorId);
            
            CreateTable(
                "dbo.Books",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ISBN = c.String(),
                        Image = c.Binary(),
                        QtyAvailable = c.Byte(nullable: false),
                        QtyReserved = c.Byte(nullable: false),
                        GenreId = c.Int(nullable: false),
                        AuthorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Exchanges",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PickupDeadline = c.DateTime(nullable: false),
                        ActionDate = c.DateTime(nullable: false),
                        BookId = c.Int(nullable: false),
                        ActionByUserId = c.Int(nullable: false),
                        ActionId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Genres",
                c => new
                    {
                        GenreId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.GenreId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Genres");
            DropTable("dbo.Exchanges");
            DropTable("dbo.Books");
            DropTable("dbo.Authors");
            DropTable("dbo.Actions");
        }
    }
}
