using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using TicketPeru.Models;

namespace TicketPeru.Util.Helpers
{

    public class EmailHelpers
    {
        public EmailHelpers()
        {
        }

        public Boolean SendContactEmail(String NombreEvento, String Local, String TipoEvento, DateTime? FechaEvento, String NombreSolicitante, String CorreoSolicitante, String TelefonoSolicitante, String ComentarioSolicitante)
        {
            try
            {
                var senderEmail = new MailAddress(ConstantHelpers.CORREO_SERVIDOR_USUARIO, "rrios@ticketperu.pe");
                var receiverEmail = new MailAddress("rrios@ticketperu.pe", "Contactos");
                var password = ConstantHelpers.CORREO_SERVIDOR_CLAVE;
                var subject = "NUEVO CONTACTO WEB - TICKET PERÚ";
                var body = "<h3 style='font-weight: 700;'>Datos del Evento</h3> Nombre del Evento: " + NombreEvento + "<br> Local: " + Local + "<br> Tipo de Evento: " + TipoEvento + "<br> Fecha de Evento: " + FechaEvento.ToString() + "<br> <h3 style='font-weight: 700;'>Datos del Solicitante</h3>" + "Nombre Completo: " + NombreSolicitante + "<br> Correo: " + CorreoSolicitante + "<br> Teléfono: " + TelefonoSolicitante + "<br> Comentarios: " + ComentarioSolicitante;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }

        public Boolean SendClaimEmail(String Nombres, String Apellidos, String DNI, String Email, String Telefono, String Direccion, String Incidencia, String Tipo, String DescripcionTipo, String DescripcionReclamo)
        {
            try
            {
                var senderEmail = new MailAddress(ConstantHelpers.CORREO_SERVIDOR_USUARIO, "reclamos@ticketperu.pe");
                var receiverEmail = new MailAddress("reclamos@ticketperu.pe", "Reclamos");
                var password = ConstantHelpers.CORREO_SERVIDOR_CLAVE;
                var subject = "NUEVO RECLAMO/QUEJA - WEB TICKET PERÚ";
                var body = "<h3 style='font-weight: 700;'>Datos Personales</h3> Nombres: " + Nombres + "<br> Apellidos: " + Apellidos + "<br> DNI: " + DNI + "<br> Email: " + Email + "<br> Teléfono: " + Telefono + "<br> Dirección: " + Direccion + "<br> <h3 style='font-weight: 700;'>Detalles de la Incidencia</h3>" + "Fecha: " + DateTime.Now.ToString() + "<br> Tipo: " + Incidencia + "<br> Relacionado a: " + Tipo + "<br> Descripción Producto o Servicio: " + DescripcionTipo + "<br> Detalles de la Incidencia: " + DescripcionReclamo;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }

        public Boolean SendMensajeEmail(String Nombres, String Apellidos, String Email, String Empresa, String Departamento, String Mensaje)
        {
            try
            {
                var senderEmail = new MailAddress(ConstantHelpers.CORREO_SERVIDOR_USUARIO, "informes@ticketperu.pe");
                var receiverEmail = new MailAddress("informes@ticketperu.pe", "Mensaje");
                var password = ConstantHelpers.CORREO_SERVIDOR_CLAVE;
                var subject = "NUEVO MENSAJE - WEB TICKET PERÚ";
                var body = "<h3 style='font-weight: 700;'>Datos Personales</h3> Nombres: " + Nombres + "<br> Apellidos: " + Apellidos + "<br> Email: " + Email + "<br> Empresa: " + Empresa + "<br> <h3 style='font-weight: 700;'>Detalles del mensaje</h3>" + "Fecha: " + DateTime.Now.ToString() + "<br> Para Departamento: " + Departamento + "<br> Mensaje: " + Mensaje;
                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(senderEmail.Address, password)
                };
                using (var mess = new MailMessage(senderEmail, receiverEmail)
                {
                    Subject = subject,
                    IsBodyHtml = true,
                    Body = body
                })
                {
                    smtp.Send(mess);
                }
                return true;

            }
            catch 
            {
                return false;
            }
        }
    }
}