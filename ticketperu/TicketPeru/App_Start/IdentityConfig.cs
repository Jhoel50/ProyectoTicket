using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security;
using TicketPeru.Models;
using TicketPeru.Util.Validators;
using System.Net.Mail;
using System.Net.Mime;
using TicketPeru.Util.Helpers;

namespace TicketPeru
{
    public class EmailService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            if (message.Subject.Equals("CONFIRMAR EMAIL - TICKET PERÚ"))
            {
                return sendEmailConfirmationMail(message);
            }

            if (message.Subject.Equals("RESTABLECER CONTRASEÑA - TICKET PERÚ"))
            {
                return sendResetPasswordMail(message);
            }

            return Task.FromResult(0);
        }

        private Task sendEmailConfirmationMail(IdentityMessage message)
        {
            #region formatter
            string htmlLink = "<a href=\"" + message.Body + "\">enlace</a>";
            string text = "¡Estamos felices de darle la bienvenida a la familia de TICKETPERU!, Gracias por elegirnos para nosotros es un privilegio servirle. <br/><br/>";
            text += string.Format("Por favor confirme su email haciendo click al siguiente {0}", htmlLink);

            string html = "¡Estamos felices de darle la bienvenida a la familia de TICKETPERU!, Gracias por elegirnos para nosotros es un privilegio servirle. <br/><br/>";
            html += "Por favor confirme su email haciendo click al siguiente " + htmlLink + "<br/><br/>";
            html += HttpUtility.HtmlEncode(@"También puede copiar y pegar este enlace en cualquier navegador: " + message.Body);
            #endregion

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConstantHelpers.CORREO_SERVIDOR_USUARIO, "informes@ticketperu.pe");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConstantHelpers.CORREO_SERVIDOR_USUARIO, ConstantHelpers.CORREO_SERVIDOR_CLAVE);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return Task.FromResult(0);
        }

        private Task sendResetPasswordMail(IdentityMessage message)
        {
            #region formatter
            string htmlLink = "<a href=\"" + message.Body + "\">enlace</a>";
            string text = string.Format("Por favor restablezca su contraseña haciendo click al siguiente {0}", htmlLink);
            string html = "Por favor restablezca su contraseña haciendo click al siguiente " + htmlLink + "<br/><br/>";
            html += HttpUtility.HtmlEncode(@"También puede copiar y pegar este enlace en cualquier navegador: " + message.Body);
            #endregion

            MailMessage msg = new MailMessage();
            msg.From = new MailAddress(ConstantHelpers.CORREO_SERVIDOR_USUARIO, "informes@ticketperu.pe");
            msg.To.Add(new MailAddress(message.Destination));
            msg.Subject = message.Subject;
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(text, null, MediaTypeNames.Text.Plain));
            msg.AlternateViews.Add(AlternateView.CreateAlternateViewFromString(html, null, MediaTypeNames.Text.Html));

            SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", Convert.ToInt32(587));
            System.Net.NetworkCredential credentials = new System.Net.NetworkCredential(ConstantHelpers.CORREO_SERVIDOR_USUARIO, ConstantHelpers.CORREO_SERVIDOR_CLAVE);
            smtpClient.Credentials = credentials;
            smtpClient.EnableSsl = true;
            smtpClient.Send(msg);

            return Task.FromResult(0);
        }
    }

    public class SmsService : IIdentityMessageService
    {
        public Task SendAsync(IdentityMessage message)
        {
            // Plug in your SMS service here to send a text message.
            return Task.FromResult(0);
        }
    }

    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
    public class ApplicationUserManager : UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store)
            : base(store)
        {
            //PasswordValidator = new MinimumLengthValidator(4);
        }
       //public ApplicationUserManager() : base(new UserStore<ApplicationUser>(new ApplicationDbContext()))
       //{
       //  PasswordValidator = new MinimumLengthValidator(10);
       //}

       public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context) 
        {
            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
            // Configure validation logic for usernames
            manager.UserValidator = new CustomUserValidator<ApplicationUser>(manager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            //manager.PasswordValidator = new PasswordValidator
            //{
            //    RequiredLength = 6,
            //    RequireNonLetterOrDigit = true,
            //    RequireDigit = true,
            //    RequireLowercase = true,
            //    RequireUppercase = true,

            //};
            manager.PasswordValidator = new CustomPasswordValidator(4,20);
            //manager.PasswordValidator = new CustomPasswordValidator
            //{
            //    RequiredLength = 4,
            //    RequireNonLetterOrDigit = false,
            //    RequireDigit = true,
            //    RequireLowercase = false,
            //    RequireUppercase = false,
            //    MaxLength = 5
            //};


            // Configure user lockout defaults
            manager.UserLockoutEnabledByDefault = true;
            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
            // You can write your own provider and plug it in here.
            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
            {
                MessageFormat = "Your security code is {0}"
            });
            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
            {
                Subject = "Security Code",
                BodyFormat = "Your security code is {0}"
            });
            manager.EmailService = new EmailService();
            manager.SmsService = new SmsService();
            var dataProtectionProvider = options.DataProtectionProvider;
            if (dataProtectionProvider != null)
            {
                manager.UserTokenProvider = 
                    new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
            }
            return manager;
        }
    }

    // Configure the application sign-in manager which is used in this application.
    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}
