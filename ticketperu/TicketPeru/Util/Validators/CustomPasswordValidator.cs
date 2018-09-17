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
    public class CustomPasswordValidator : IIdentityValidator<string>
    //public class CustomPasswordValidator : PasswordValidator
    {
        public int MaxLength { get; set; }
        public int RequiredLength { get; set; }
        //    public bool RequireNonLetterOrDigit { get; set; }
        //    public bool RequireDigit { get; set; }
        //    public bool RequireLowercase { get; set; }
        //    public bool RequireUppercase { get; set; }

        public CustomPasswordValidator(int lengthmin, int lengthmax)
        {

            RequiredLength = lengthmin;
            MaxLength = lengthmax;
            //    RequireNonLetterOrDigit = false;
            //    RequireDigit = false;
            //    RequireLowercase = false;
            //    RequireUppercase = false;

        }
        //public override async Task<IdentityResult> ValidateAsync(string item)
        //    {
        //        var result = await base.ValidateAsync(item);
        //        if (item.Contains(" "))
        //        {
        //            var errors = result.Errors.ToList();
        //            errors.Add("El password no puede contener espacios en blanco");
        //            result = new IdentityResult(errors);
        //        }
        //        return result;
        //    }
        //}
        //public Task<IdentityResult> ValidateAsync(string item)
        //public override async Task<IdentityResult> ValidateAsync(string item)
        //{


        //    IdentityResult result = await base.ValidateAsync(item);

        //    var errors = result.Errors.ToList();

        //    if (string.IsNullOrEmpty(item) || item.Length > MaxLength)
        //    {
        //        errors.Add(string.Format("Password length can't exceed {0}", MaxLength));
        //    }
         //return await Task.FromResult(!errors.Any()
         //    ? IdentityResult.Success
         //    : IdentityResult.Failed(errors.ToArray()));
        
    //}
       public Task<IdentityResult> ValidateAsync(string item)
        { 
           
            if (String.IsNullOrEmpty(item) || item.Length < RequiredLength || item.Length > MaxLength) 
            {
                return Task.FromResult(IdentityResult.Failed("La contraseña debe contener entre 4 y 20 caracteres. (no permitido caracteres especiales)"));
            }

            //string pattern = @"^(?=.*[0-9])(?=.*[!@#$%^&*])[0-9a-zA-Z!@#$%^&*0-9]{10,}$";
            //if (!Regex.IsMatch(item, pattern))
            //{
            //    return Task.FromResult(IdentityResult.Failed("Password should have one numeral and one special character"));
            //}
            return Task.FromResult(IdentityResult.Success);
        }
    }
}