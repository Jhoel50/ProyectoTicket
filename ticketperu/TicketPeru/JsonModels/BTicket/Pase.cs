using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Pase
    {
        public int idPase { get; set; }
        public string nombrePase { get; set; }
        public string descripcionPase { get; set; }
        public string descripcionLargaPase { get; set; }
        public int idRecinto { get; set; }
        public int EstadoPase { get; set; }
        public string DescripicionEstadoPase { get; set; }
        public string fechaPase { get; set; }
        public string fechaPorConfirmar { get; set; }
        public string imagen { get; set; }
        public string imagen_mini { get; set; }
        public string imagen_media { get; set; }
        public int destacado { get; set; }
        public Producto[] Productos { get; set; }
    }
}