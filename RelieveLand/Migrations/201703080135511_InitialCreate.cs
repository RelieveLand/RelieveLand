namespace RelieveLand.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EstablishmentModels",
                c => new
                    {
                        EstID = c.Int(nullable: false, identity: true),
                        EstName = c.String(),
                        EstImage = c.String(),
                        EstAddress = c.String(),
                        ZipCode = c.Int(nullable: false),
                        BoroughPrimary = c.String(),
                        BoroughSecondary = c.String(),
                        HoursOfOper = c.String(),
                        SingleStall = c.Boolean(nullable: false),
                        HandDryer = c.String(),
                        ChangingStation = c.Boolean(nullable: false),
                        PurchaseNeeded = c.Boolean(nullable: false),
                        HandicapStall = c.Boolean(nullable: false),
                        HygieneProducts = c.Boolean(nullable: false),
                        FamilyRestroom = c.Boolean(nullable: false),
                        Extras = c.String(),
                        OverallAvg = c.Single(nullable: false),
                        OdorAvg = c.Single(nullable: false),
                        AppearAvg = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.EstID);
            
            CreateTable(
                "dbo.ReviewModels",
                c => new
                    {
                        ReviewID = c.Int(nullable: false, identity: true),
                        ReviewTime = c.String(),
                        OverallRating = c.Int(nullable: false),
                        OdorRating = c.Int(nullable: false),
                        AppearRating = c.Int(nullable: false),
                        UserComments = c.String(),
                        EstID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ReviewID)
                .ForeignKey("dbo.EstablishmentModels", t => t.EstID, cascadeDelete: true)
                .Index(t => t.EstID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReviewModels", "EstID", "dbo.EstablishmentModels");
            DropIndex("dbo.ReviewModels", new[] { "EstID" });
            DropTable("dbo.ReviewModels");
            DropTable("dbo.EstablishmentModels");
        }
    }
}
