namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRoleDescriptionToRole : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Roles", "RoleDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Roles", "RoleDescription");
        }
    }
}
