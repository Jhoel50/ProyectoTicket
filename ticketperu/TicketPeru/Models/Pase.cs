using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.Models
{
    public class Pase
    {
        public int ID { get; set; }
        public int BTPaseID { get; set; }
        public string NombrePase { get; set; }
        public string DescripcionPase { get; set; }
        public string DescripcionLargaPase { get; set; }
        public int RecintoID { get; set; }
        public string NombreRecinto { get; set; }
        public int EstadoPase { get; set; }
        public string DescripcionEstadoPase { get; set; }
        public string FechaPase { get; set; }
        public string FechaPorConfirmar { get; set; }
        public string Imagen { get; set; }
        public string ImagenMini { get; set; }
        public string ImagenMedia { get; set; }
        public int Destacado { get; set; }
        public int EventoID { get; set; }
        public double PrecioMinimo { get; set; }
    }
}