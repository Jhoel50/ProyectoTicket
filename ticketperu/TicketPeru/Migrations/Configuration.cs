namespace TicketPeru.Migrations
{
    using Microsoft.AspNet.Identity;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin.Security.DataProtection;
    using Microsoft.AspNet.Identity.Owin;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketPeru.Models.ApplicationDbContext>
    {
        private UserManager<ApplicationUser> UserManager { get; set; }
        private ApplicationDbContext ApplicationDbContext { get; set; }

        public Configuration()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));

            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TicketPeru.Models.ApplicationDbContext context)
        {
            var existingAdmin = this.UserManager.FindByEmail("admin@ticketperu.pe");

            if (existingAdmin == null)
            {
                var admin = new ApplicationUser
                {
                    UserName = "admin@ticketperu.pe",
                    Email = "admin@ticketperu.pe",
                    Nombres = "Admin",
                    Apellidos = "TicketPeru",
                    TipoDocumentoID = 1,
                    Documento = "00000000"
                };

                this.UserManager.Create(admin, "Admin.tp");
                var provider = new DpapiDataProtectionProvider("Sample");
                this.UserManager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(provider.Create("EmailConfirmation"));
                string code = UserManager.GenerateEmailConfirmationToken(admin.Id);
                this.UserManager.ConfirmEmail(admin.Id, code);
            }
        }
    }
}
