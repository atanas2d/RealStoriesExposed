namespace RealStoriesExposed.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MyFridayMigration : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Stories");
            AlterColumn("dbo.Stories", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Stories", "Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Stories");
            AlterColumn("dbo.Stories", "Id", c => c.Guid(nullable: false));
            AddPrimaryKey("dbo.Stories", "Id");
        }
    }
}
