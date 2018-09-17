namespace TicketPeru.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Evento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BTEventoID = c.Int(nullable: false),
                        NombreEvento = c.String(),
                        DescripcionEvento = c.String(),
                        DescripcionLargaEvento = c.String(),
                        TipoEventoID = c.Int(nullable: false),
                        EstadoEvento = c.Int(nullable: false),
                        DescripcionEstadoEvento = c.String(),
                        CodigoExtra = c.String(),
                        Imagen = c.String(),
                        ImagenMini = c.String(),
                        ImagenMedia = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.TipoEvento", t => t.TipoEventoID, cascadeDelete: true)
                .Index(t => t.TipoEventoID);
            
            CreateTable(
                "dbo.Pase",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BTPaseID = c.Int(nullable: false),
                        NombrePase = c.String(),
                        DescripcionPase = c.String(),
                        DescripcionLargaPase = c.String(),
                        RecintoID = c.Int(nullable: false),
                        NombreRecinto = c.String(),
                        EstadoPase = c.Int(nullable: false),
                        DescripcionEstadoPase = c.String(),
                        FechaPase = c.String(),
                        FechaPorConfirmar = c.String(),
                        Imagen = c.String(),
                        ImagenMini = c.String(),
                        ImagenMedia = c.String(),
                        Destacado = c.Int(nullable: false),
                        EventoID = c.Int(nullable: false),
                        PrecioMinimo = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Evento", t => t.EventoID, cascadeDelete: true)
                .Index(t => t.EventoID);
            
            CreateTable(
                "dbo.TipoEvento",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        BTTipoEventoID = c.Int(nullable: false),
                        IdiomaID = c.Int(nullable: false),
                        Descripcion = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        BTId = c.String(),
                        Nombres = c.String(),
                        Apellidos = c.String(),
                        TipoDocumentoID = c.Int(nullable: false),
                        Documento = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Evento", "TipoEventoID", "dbo.TipoEvento");
            DropForeignKey("dbo.Pase", "EventoID", "dbo.Evento");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Pase", new[] { "EventoID" });
            DropIndex("dbo.Evento", new[] { "TipoEventoID" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.TipoEvento");
            DropTable("dbo.Pase");
            DropTable("dbo.Evento");
        }
    }
}
