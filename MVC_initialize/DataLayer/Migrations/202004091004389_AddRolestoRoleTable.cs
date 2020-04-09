namespace DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddRolestoRoleTable : DbMigration
    {
        public override void Up()
        {Sql(@"INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (0, N'Admin', N'مدیر کل سیستم')
INSERT [dbo].[Roles] ([Id], [RoleName], [RoleDescription]) VALUES (1, N'User', N'کاربر عادی')");
        }
        
        public override void Down()
        {
        }
    }
}
