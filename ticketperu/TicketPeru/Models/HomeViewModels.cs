using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketPeru.JsonModels.BTicket;

namespace TicketPeru.Models
{
    public class HomeIndexViewModel
    {
        public List<TicketPeru.Models.TipoEvento> tipoEventos;
        public List<TicketPeru.Models.Evento> eventos;
        public List<TicketPeru.Models.Pase> pases;
        public List<TicketPeru.Models.Pase> pasesDestacados;
        public String Buscar;
        public String Meses;
        public Int32? TipoEvento;
        public String Filtro;

        public static List<SelectListItem> MesesFiltro = new List<SelectListItem>()
        {
            new SelectListItem() {Text="ENERO - MARZO", Value="ENERO-MARZO"},
            new SelectListItem() { Text="ABRIL - JUNIO", Value="ABRIL-JUNIO"},
            new SelectListItem() { Text="JULIO  - SETIEMBRE", Value="JULIO-SETIEMBRE"},
            new SelectListItem() { Text="OCTUBRE - DICIEMBRE", Value="OCTUBRE-DICIEMBRE"}
        };

        public static List<SelectListItem> Filtros = new List<SelectListItem>()
        {
            new SelectListItem() {Text="DESTACADOS", Value="DESTACADOS"},
            new SelectListItem() { Text="TODOS", Value="TODOS"}
        };

    }

    public class EventDetailViewModel
    {
        public TicketPeru.Models.Pase paseActual;
        public TicketPeru.Models.Evento eventoActual;
        public Producto[] ListProductos;
    }

    public class ContactViewModel
    {
        [Required]
        public String NombreEvento { get; set; }

        [Required]
        public String Local { get; set; }

        [Required]
        public String TipoEvento { get; set; }

        [Required]
        public DateTime? FechaEvento { get; set; }

        [Required]
        [Display(Name = "Nombre Completo")]
        public String NombreSolicitante { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public String CorreoSolicitante { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public String TelefonoSolicitante { get; set; }

        public String ComentarioSolicitante { get; set; }
        public List<TicketPeru.Models.TipoEvento> tipoEventos;
    }

    public class ClaimViewModel
    {
        [Required]
        public String Nombres { get; set; }

        [Required]
        public String Apellidos { get; set; }

        [Required]
        public String DNI { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Telefono { get; set; }

        [Required]
        public String Direccion { get; set; }

        [Required]
        [Display(Name = "Tipo")]
        public String Incidencia { get; set; }
        [Required]
        [Display(Name = "Relacionado a")]
        public String Tipo { get; set; }
        [Required]
        [Display(Name = "Descripción Producto o Servicio")]
        public String DescripcionTipo { get; set; }
        [Required]
        [Display(Name = "Detalles del Reclamo")]
        public String DescripcionReclamo { get; set; }

        public static List<SelectListItem> Incidencias = new List<SelectListItem>()
        {
            new SelectListItem() {Text="QUEJA", Value="QUEJA"},
            new SelectListItem() { Text="RECLAMO", Value="RECLAMO"}
        };

        public static List<SelectListItem> Tipos = new List<SelectListItem>()
        {
            new SelectListItem() {Text="PRODUCTO", Value="PRODUCTO"},
            new SelectListItem() { Text="SERVICIO", Value="SERVICIO"}
        };
    }


    public class MensajeViewModel
    {
        [Required]
        public String Nombres { get; set; }

        [Required]
        public String Apellidos { get; set; }

        [Required]
        public String Email { get; set; }

        [Required]
        public String Empresa { get; set; }

      
        [Required]
        [Display(Name = "Departamento")]
        public String Departamento { get; set; }
       
        [Required]
        [Display(Name = "Su pregunta")]
        public String Mensaje { get; set; }
        
        public static List<SelectListItem> Departamentos = new List<SelectListItem>()
        {
            new SelectListItem() {Text="Soporte", Value="SOPORTE"},
            new SelectListItem() { Text="Marketing", Value="MARKETING"}
        };

      
    }
}