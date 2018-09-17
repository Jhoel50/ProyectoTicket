using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Response
    {
        public string val { get; set; }
        public string resp { get; set; }
        public string msg { get; set; }
        public int err { get; set; }
    }
}