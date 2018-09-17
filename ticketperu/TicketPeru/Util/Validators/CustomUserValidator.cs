using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using TicketPeru.Models;

namespace TicketPeru.Util.Validators
{
    public class CustomUserValidator<TUser> : UserValidator<TUser, string>
        where TUser : ApplicationUser
    {
        /// <summary>
        ///     Constructor
        /// </summary>
        /// <param name="manager"></param>
        public CustomUserValidator(UserManager<TUser, string> manager) : base(manager)
        {
            this.Manager = manager;
            this.db = ApplicationDbContext.Create();
        }
              
        private UserManager<TUser, string> Manager { get; set; }
        private ApplicationDbContext db;

        /// <summary>
        ///     Validates a user before saving
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public override async Task<IdentityResult> ValidateAsync(TUser item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            var errors = new List<string>();

            await ValidateUserName(item, errors);
            await ValidateDocumento(item, errors);

            if (RequireUniqueEmail)
            {
                await ValidateEmail(item, errors);
            }

            if (errors.Count > 0)
            {
                return IdentityResult.Failed(errors.ToArray());
            }

            return IdentityResult.Success;
        }

        private async Task ValidateUserName(TUser user, List<string> errors)
        {
            if (string.IsNullOrWhiteSpace(user.UserName))
            {
                errors.Add("Ingrese un nombre de usuario válido.");
            }
            else if (AllowOnlyAlphanumericUserNames && !Regex.IsMatch(user.UserName, @"^[A-Za-z0-9@_\.]+$"))
            {
                // If any characters are not letters or digits, its an illegal user name
                errors.Add("Nombre de usuario no válido.");
            }
            else
            {
                var owner = await Manager.FindByNameAsync(user.UserName);
                if (owner != null && !EqualityComparer<string>.Default.Equals(owner.Id, user.Id))
                {
                    //errors.Add(String.Format(CultureInfo.CurrentCulture, Resources.DuplicateName, user.UserName));
                }
            }
        }

        private async Task ValidateDocumento(TUser user, List<string> errors)
        {
            var existingUser = db.Users.Where(x => x.Documento == user.Documento).FirstOrDefault();

            if (existingUser != null && user.Id != existingUser.Id)
            {
                errors.Add("Este DNI ya se encuentra registrado.");
            }
        }

        // make sure email is not empty, valid, and unique
        private async Task ValidateEmail(TUser user, List<string> errors)
        {
            if (!string.IsNullOrWhiteSpace(user.Email))
            {
                if (string.IsNullOrWhiteSpace(user.Email))
                {
                    errors.Add("Ingrese un email válido.");
                    return;
                }
                try
                {
                    var m = new MailAddress(user.Email);
                }
                catch (FormatException)
                {
                    errors.Add("Email no válido.");
                    return;
                }
            }
            var owner = await Manager.FindByEmailAsync(user.Email);
            if (owner != null && !EqualityComparer<string>.Default.Equals(owner.Id, user.Id))
            {
                errors.Add("Este email ya se encuentra registrado.");
            }
        }
    }
}