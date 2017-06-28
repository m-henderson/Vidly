namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SeedUsers : DbMigration
    {
        public override void Up()
        {
            Sql(@"
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'4c682d1b-b95e-4742-aa5e-a12b9598ee15', N'guest@vidly.com', 0, N'AJRLZLd7sM+lJr6CjU/pcqFsJ0xcaP24e6h4I1yRYBt9pnLaO4OQqGCmGzWChMkPQw==', N'3c84a374-fad1-4004-8c0f-c62568e2e389', NULL, 0, 0, NULL, 1, 0, N'guest@vidly.com')
INSERT INTO [dbo].[AspNetUsers] ([Id], [Email], [EmailConfirmed], [PasswordHash], [SecurityStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEndDateUtc], [LockoutEnabled], [AccessFailedCount], [UserName]) VALUES (N'9ca84cc5-b536-4481-9a71-6c2516907518', N'admin@vidly.com', 0, N'AIkjq5KA4e9poez9p3CF0o81lSlcmXgaXLXevsJBs+lYB30q5bQDVNc+MuHGmeWp6Q==', N'bde2d4ff-c4f3-47fe-a00c-699cfd7de9bd', NULL, 0, 0, NULL, 1, 0, N'admin@vidly.com')

INSERT INTO [dbo].[AspNetRoles] ([Id], [Name]) VALUES (N'7db4f1fa-e6a8-4011-ac93-86aa06b8d353', N'CanManageMovies')

INSERT INTO [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9ca84cc5-b536-4481-9a71-6c2516907518', N'7db4f1fa-e6a8-4011-ac93-86aa06b8d353')


");
        }
        
        public override void Down()
        {
        }
    }
}
