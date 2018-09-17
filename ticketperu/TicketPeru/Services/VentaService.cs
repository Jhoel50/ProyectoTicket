using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TicketPeru.JsonModels.BTicket;
using TicketPeru.Util.BTicket;

namespace TicketPeru.Services
{
    public class VentaService
    {
        public async Task<String> obtenerUrlVentaDeBTicket(Int32? idUsuarioBTicket, String idUsuarioTicketPeru, int idPaseBTicket, int idEventoBTicket, int idIdioma)
        {
            var parametros = new
            {
                IdIdioma = idIdioma,
                IdUsuario = idUsuarioBTicket,
                IdPase = idPaseBTicket,
                IdEvento = idEventoBTicket,
                referencia = idUsuarioTicketPeru
            };

            var json = JsonConvert.SerializeObject(parametros);
            string resultado;

            try
            {
                resultado = await BTicketAPI.MakePostRequestAsync("venta/accesoventa", json);
            }
            catch(Exception e)
            {
                throw e;
            }
            
            Response response = JsonConvert.DeserializeObject<Response>(resultado);

            if(response.val != "0")
            {
                String urlVenta = response.resp;
                return urlVenta;
            }
            else
            {
                throw new Exception("Error en la respuesta de bTicket: " + response.err);
            }
        }

        public async Task<String> obtenerUrlMisComprasDeBTicket(int idUsuarioBTicket, string idUsuarioTicketPeru, int idIdioma)
        {
            var parametros = new
            {
                IdIdioma = idIdioma,
                IdUsuario = idUsuarioBTicket,
                referencia = idUsuarioTicketPeru
            };

            var json = JsonConvert.SerializeObject(parametros);
            string resultado;

            try
            {
                resultado = await BTicketAPI.MakePostRequestAsync("venta/accesoCompras", json);
            }
            catch (Exception e)
            {
                throw e;
            }

            Response response = JsonConvert.DeserializeObject<Response>(resultado);

            if (response.val != "0")
            {
                String urlMisCompras = response.resp;
                return urlMisCompras;
            }
            else
            {
                throw new Exception("Error en la respuesta de bTicket: " + response.err);
            }
        }
    }
}