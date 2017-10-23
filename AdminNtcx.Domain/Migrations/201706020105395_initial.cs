namespace AdminNtcx.Domain.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserInfoes", "UserName", c => c.String(nullable: false));
            AlterColumn("dbo.UserInfoes", "RealName", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserInfoes", "RealName", c => c.String());
            AlterColumn("dbo.UserInfoes", "UserName", c => c.String());
        }
    }
}
