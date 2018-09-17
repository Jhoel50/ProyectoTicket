using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.Models
{
    public class TipoEvento
    {
        public int ID { get; set; }
        public int BTTipoEventoID { get; set; }
        public int IdiomaID { get; set; }
        public string Descripcion { get; set; }
    }
}