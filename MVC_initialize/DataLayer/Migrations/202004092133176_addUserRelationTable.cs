namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addUserRelationTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAndRoleRealations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Roles_Id = c.Byte(),
                        User_UserID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Roles", t => t.Roles_Id)
                .ForeignKey("dbo.Users", t => t.User_UserID)
                .Index(t => t.Roles_Id)
                .Index(t => t.User_UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.UserAndRoleRealations", "User_UserID", "dbo.Users");
            DropForeignKey("dbo.UserAndRoleRealations", "Roles_Id", "dbo.Roles");
            DropIndex("dbo.UserAndRoleRealations", new[] { "User_UserID" });
            DropIndex("dbo.UserAndRoleRealations", new[] { "Roles_Id" });
            DropTable("dbo.UserAndRoleRealations");
        }
    }
}
