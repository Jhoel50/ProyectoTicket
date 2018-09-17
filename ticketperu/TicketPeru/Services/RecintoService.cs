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
    public class RecintoService
    {
        public async Task<List<Recinto>> getZonasSectores(int idRecinto, int idIdioma)
        {
            var parametros = new
            {
                IdRecinto = idRecinto,
                IdIdioma = idIdioma
            };

            var json = JsonConvert.SerializeObject(parametros);
            string resultado = await BTicketAPI.MakePostRequestAsync("recintos/getzonassectores", json);
            Response response = JsonConvert.DeserializeObject<Response>(resultado);
            List<Recinto> respuesta = JsonConvert.DeserializeObject<List<Recinto>>(response.resp);

            return respuesta;
        }
    }
}