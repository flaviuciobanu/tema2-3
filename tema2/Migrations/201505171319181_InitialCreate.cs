namespace tema2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Beres",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Nume = c.String(),
                        DataFabricatie = c.DateTime(nullable: false),
                        ProcentAlcool = c.Double(nullable: false),
                        Pret = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Beres");
        }
    }
}
