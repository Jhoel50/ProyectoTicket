using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TicketPeru.Models
{
    public class EditUserViewModel
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo Nombres solo debe contener letras.")]
        [StringLength(60, ErrorMessage = "El campo Nombres no puede tener más de 60 caracteres.")]
        public string Nombres { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "El campo Apellidos solo debe contener letras.")]
        [StringLength(60, ErrorMessage = "El campo Apellidos no puede tener más de 60 caracteres.")]
        public string Apellidos { get; set; }

        [Required]
        [Display(Name = "DNI")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "El DNI debe tener exactamente 8 caracteres en total.")]
        [Range(0, int.MaxValue, ErrorMessage = "El DNI no puede contener letras.")]
        public string Documento { get; set; }
    }
}