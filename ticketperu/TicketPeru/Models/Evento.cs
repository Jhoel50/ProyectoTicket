using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.Models
{
    public class Evento
    {
        public int ID { get; set; }
        public int BTEventoID { get; set; }
        public string NombreEvento { get; set; }
        public string DescripcionEvento { get; set; }
        public string DescripcionLargaEvento { get; set; }
        public int TipoEventoID { get; set; }
        public int EstadoEvento { get; set; }
        public string DescripcionEstadoEvento { get; set; }
        public string CodigoExtra { get; set; }
        public string Imagen { get; set; }
        public string ImagenMini { get; set; }
        public string ImagenMedia { get; set; }

        public virtual ICollection<Pase> Pases { get; set; }
        public virtual TipoEvento TipoEvento { get; set; }
    }
}