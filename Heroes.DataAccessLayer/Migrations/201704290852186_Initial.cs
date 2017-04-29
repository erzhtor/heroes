namespace Heroes.DataAccessLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Description = c.String(maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Heroes",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NickName = c.String(nullable: false, maxLength: 100),
                        CountryID = c.Int(nullable: false),
                        IsMale = c.Boolean(nullable: false),
                        DateOfBirth = c.DateTime(nullable: false, storeType: "date"),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Countries", t => t.CountryID, cascadeDelete: true)
                .Index(t => t.CountryID);
            
            CreateTable(
                "dbo.Powers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        Description = c.String(maxLength: 500),
                        CreatedAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.HeroesToPowers",
                c => new
                    {
                        HeroID = c.Int(nullable: false),
                        PowerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.HeroID, t.PowerID })
                .ForeignKey("dbo.Heroes", t => t.HeroID, cascadeDelete: true)
                .ForeignKey("dbo.Powers", t => t.PowerID, cascadeDelete: true)
                .Index(t => t.HeroID)
                .Index(t => t.PowerID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Heroes", "CountryID", "dbo.Countries");
            DropForeignKey("dbo.HeroesToPowers", "PowerID", "dbo.Powers");
            DropForeignKey("dbo.HeroesToPowers", "HeroID", "dbo.Heroes");
            DropIndex("dbo.HeroesToPowers", new[] { "PowerID" });
            DropIndex("dbo.HeroesToPowers", new[] { "HeroID" });
            DropIndex("dbo.Heroes", new[] { "CountryID" });
            DropTable("dbo.HeroesToPowers");
            DropTable("dbo.Powers");
            DropTable("dbo.Heroes");
            DropTable("dbo.Countries");
        }
    }
}
