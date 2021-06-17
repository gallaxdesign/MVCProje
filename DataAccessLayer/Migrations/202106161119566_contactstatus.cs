namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class contactstatus : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contacts", "ContactUnread", c => c.Boolean(nullable: false));
            AddColumn("dbo.Contacts", "ContactStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contacts", "ContactStatus");
            DropColumn("dbo.Contacts", "ContactUnread");
        }
    }
}
