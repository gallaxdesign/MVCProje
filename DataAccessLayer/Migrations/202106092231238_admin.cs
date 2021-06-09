namespace DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class admin : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        AdminID = c.Int(nullable: false, identity: true),
                        AdminName = c.String(maxLength: 50),
                        AdminSurName = c.String(maxLength: 50),
                        AdminUsername = c.String(maxLength: 50),
                        AdminPassword = c.String(maxLength: 200),
                        AdminImage = c.String(maxLength: 250),
                        AdminAbout = c.String(maxLength: 100),
                        AdminMail = c.String(maxLength: 200),
                        AdminRole = c.String(maxLength: 1),
                        AdminStatus = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.AdminID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Admins");
        }
    }
}
