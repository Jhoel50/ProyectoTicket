using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Evento
    {
        public int idEvento { get; set; }
        public string NombreEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public string DescripcionLargaEvento { get; set; }
        public int idTipoEvento { get; set; }
        public int EstadoEvento { get; set; }
        public string DescripicionEstadoEvento { get; set; }
        public string CodigoExtra { get; set; }
        public string imagen { get; set; }
        public string imagen_mini { get; set; }
        public string imagen_media { get; set; }
        public Pase[] Pases { get; set; }
    }
}