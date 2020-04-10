namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserRelationTable2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "UserName", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false, maxLength: 250));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false, maxLength: 200));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Password", c => c.String(maxLength: 200));
            AlterColumn("dbo.Users", "Email", c => c.String(maxLength: 250));
            AlterColumn("dbo.Users", "UserName", c => c.String(maxLength: 250));
        }
    }
}
