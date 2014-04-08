namespace p2_projekt.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Phone = c.String(),
                        Name = c.String(),
                        Adress_AddressLine1 = c.String(),
                        Adress_AddressLine2 = c.String(),
                        Adress_Building = c.String(),
                        Adress_City = c.String(),
                        Adress_CountryRegion = c.String(),
                        Adress_FloorLevel = c.String(),
                        Adress_PostalCode = c.String(),
                        Adress_StateProvince = c.String(),
                        MembershipNumber = c.Int(),
                        IsActive = c.Boolean(),
                        Email = c.String(),
                        Birthday = c.DateTime(),
                        Password = c.String(),
                        hasPaid = c.Boolean(),
                        Email1 = c.String(),
                        Birthday1 = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.Boats",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Lenght = c.Double(nullable: false),
                        Width = c.Double(nullable: false),
                        registrationNumber = c.String(),
                        Guest_UserId = c.Int(),
                        Owner_UserId = c.Int(),
                        Member_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Guest_UserId)
                .ForeignKey("dbo.Users", t => t.Owner_UserId)
                .ForeignKey("dbo.Users", t => t.Member_UserId)
                .Index(t => t.Guest_UserId)
                .Index(t => t.Owner_UserId)
                .Index(t => t.Member_UserId);
            
            CreateTable(
                "dbo.Travels",
                c => new
                    {
                        TravelId = c.Int(nullable: false, identity: true),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Guest_UserId = c.Int(),
                        Member_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.TravelId)
                .ForeignKey("dbo.Users", t => t.Guest_UserId)
                .ForeignKey("dbo.Users", t => t.Member_UserId)
                .Index(t => t.Guest_UserId)
                .Index(t => t.Member_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Travels", "Member_UserId", "dbo.Users");
            DropForeignKey("dbo.Boats", "Member_UserId", "dbo.Users");
            DropForeignKey("dbo.Boats", "Owner_UserId", "dbo.Users");
            DropForeignKey("dbo.Travels", "Guest_UserId", "dbo.Users");
            DropForeignKey("dbo.Boats", "Guest_UserId", "dbo.Users");
            DropIndex("dbo.Travels", new[] { "Member_UserId" });
            DropIndex("dbo.Travels", new[] { "Guest_UserId" });
            DropIndex("dbo.Boats", new[] { "Member_UserId" });
            DropIndex("dbo.Boats", new[] { "Owner_UserId" });
            DropIndex("dbo.Boats", new[] { "Guest_UserId" });
            DropTable("dbo.Travels");
            DropTable("dbo.Boats");
            DropTable("dbo.Users");
        }
    }
}
