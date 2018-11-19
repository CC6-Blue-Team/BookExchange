namespace BookDonation.DB.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelChanges : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Exchanges", "ActionID", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Exchanges", "ActionID");
        }
    }
}
