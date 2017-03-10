namespace RelieveLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedUserNameToReviewModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ReviewModels", "UserName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ReviewModels", "UserName");
        }
    }
}
