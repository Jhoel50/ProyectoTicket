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
    public class ComunService
    {
        public async Task<List<TipoEvento>> getTipoEvento(int idIdioma)
        {
            var parametros = new
            {
                IdIdioma = idIdioma
            };

            var json = JsonConvert.SerializeObject(parametros);
            string resultado;

            try
            {
                resultado = await BTicketAPI.MakePostRequestAsync("comun/gettipoevento", json);
            }
            catch (Exception e)
            {
                throw e;
            }
            
            
            Response response = JsonConvert.DeserializeObject<Response>(resultado);
            
            if(response.val != "0")
            {
                List<TipoEvento> respuesta = JsonConvert.DeserializeObject<List<TipoEvento>>(response.resp);
                return respuesta; 
            }
            else
            {
                throw new Exception("Error en la respuesta de bTicket: " + response.err);
            }
        }
    }
}