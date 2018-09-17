using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Configuration;
using System.Text;
using System.Net.Http.Headers;

namespace TicketPeru.Util.BTicket
{
    public static class BTicketAPI
    {
        /// <summary>
        /// Envía un POST Request a BTicket.
        /// </summary>
        /// <param name="comando">Comando a ser ejecutado. Por ejemplo: "pases/getPases".</param>
        /// <param name="parametrosJson">Parámetros a ser enviados en el request.</param>
        /// <returns>Retorna el response devuelto por BTicket</returns>
        public static async Task<string> MakePostRequestAsync(string comando, string parametrosJson)
        {
            var client = new HttpClient();
            string bTicketAuthorization = ConfigurationManager.AppSettings["BTicketAuthorization"];
            string urlAPI = ConfigurationManager.AppSettings["APIBTicket"];
            client.DefaultRequestHeaders.Add("Authorization", bTicketAuthorization);
          //  var uri = "https://desarrollo.bticket.es/bticket_api/" + comando;
          //  var uri = "http://localhost:60350/" + comando;
            var uri = urlAPI + comando;
            

            HttpResponseMessage response;

            byte[] byteData = Encoding.UTF8.GetBytes(parametrosJson);

            using (var content = new ByteArrayContent(byteData))
            {
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                response = await client.PostAsync(uri, content);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    throw new Exception("Error en llamada a API de BTicket");
                }
            }
        }        
    }
}