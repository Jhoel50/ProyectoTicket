using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TicketPeru.Models
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class ExternalLoginListViewModel
    {
        public string ReturnUrl { get; set; }
    }

    public class SendCodeViewModel
    {
        public string SelectedProvider { get; set; }
        public ICollection<System.Web.Mvc.SelectListItem> Providers { get; set; }
        public string ReturnUrl { get; set; }
        public bool RememberMe { get; set; }
    }

    public class VerifyCodeViewModel
    {
        [Required]
        public string Provider { get; set; }

        [Required]
        [Display(Name = "Code")]
        public string Code { get; set; }
        public string ReturnUrl { get; set; }

        [Display(Name = "Remember this browser?")]
        public bool RememberBrowser { get; set; }

        public bool RememberMe { get; set; }
    }

    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }

    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        //[RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&\.\+\-\,\/\\ñÑáéíóúÁÉÍÓÚ\s])[A-Za-z\d$@$!%*?&\.\+\-\,\/\\ñÑáéíóúÁÉÍÓÚ\s]{8,}", ErrorMessage = "La contraseña debe contener por lo menos 1 letra minúscula, 1 letra mayúscula, 1 número, 1 caracter especial (por ejemplo $) y mínimo 8 caracteres en total.")]
        [RegularExpression(@"^[a-zA-ZñÑ\d]{4,20}$", ErrorMessage = "La contraseña debe contener entre 4 y 20 caracteres. (no permitido caracteres especiales).")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El campo Nombres solo debe contener letras.")]
        [StringLength(60, ErrorMessage = "El campo Nombres no puede tener más de 60 caracteres.")]
        public string Nombres { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚ\s]+$", ErrorMessage = "El campo Apellidos solo debe contener letras.")]
        [StringLength(60, ErrorMessage = "El campo Apellidos no puede tener más de 60 caracteres.")]
        public string Apellidos { get; set; }

        //[Required]
        //public int TipoDocumentoID { get; set; }

        [Required]
        [Display(Name = "DNI")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener exactamente 8 caracteres en total.")]
        [Range(0, int.MaxValue, ErrorMessage = "El DNI no puede contener letras.")]
        public string Documento { get; set; }
    }

    public class ResetPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        //  [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[$@$!%*?&\.\+\-\,\/\\ñÑáéíóúÁÉÍÓÚ\s])[A-Za-z\d$@$!%*?&\.\+\-\,\/\\ñÑáéíóúÁÉÍÓÚ\s]{8,}", ErrorMessage = "La contraseña debe contener por lo menos 1 letra minúscula, 1 letra mayúscula, 1 número, 1 caracter especial (por ejemplo $) y mínimo 8 caracteres en total.")]
        [RegularExpression(@"^[a-zA-ZñÑ\d]{4,20}$", ErrorMessage = "La contraseña debe contener entre 4 y 20 caracteres. (no permitido caracteres especiales).")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar contraseña")]
        [Compare("Password", ErrorMessage = "Las contraseñas no coinciden.")]
        public string ConfirmPassword { get; set; }

        public string Code { get; set; }
    }

    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
