namespace RelieveLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedBoroughModels : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoroughModels",
                c => new
                    {
                        BoroughID = c.Int(nullable: false, identity: true),
                        BoroughName = c.String(),
                    })
                .PrimaryKey(t => t.BoroughID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.BoroughModels");
        }
    }
}
