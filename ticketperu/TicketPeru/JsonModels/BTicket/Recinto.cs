using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Recinto
    {
        public int idRecinto { get; set; }
        public string nombreRecinto { get; set; }
        public Zona[] Zonas { get; set; }
    }
}