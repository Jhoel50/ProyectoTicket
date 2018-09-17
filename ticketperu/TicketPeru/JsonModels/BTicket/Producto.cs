using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.JsonModels.BTicket
{
    public class Producto
    {
        public int idProducto { get; set; }
        public string nombreProducto { get; set; }
        public int EstadoProducto { get; set; }
        public string DescripicionEstadoProducto { get; set; }
        public int idSector { get; set; }
        public string NombreSector { get; set; }
        public int EstadoSector { get; set; }
        public string DescripicionEstadoSector { get; set; }
        public double precioProducto { get; set; }
        public double porCientoGastos { get; set; }
        public double gastosEmision { get; set; }
        public double gastosOrganizacion { get; set; }
        public double precio { get; set; }
    }
}