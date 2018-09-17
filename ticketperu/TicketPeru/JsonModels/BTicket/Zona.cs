using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Zona
    {
        public int idZona { get; set; }
        public string nombreZona { get; set; }
        public Sector[] Sectores { get; set; }
    }
}