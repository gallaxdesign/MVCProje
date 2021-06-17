namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class messagestatusedit : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Messages", "MessageStatus", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Messages", "MessageStatus", c => c.String());
        }
    }
}
