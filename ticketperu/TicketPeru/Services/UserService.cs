using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TicketPeru.JsonModels.BTicket;
using TicketPeru.Models;
using TicketPeru.Util.BTicket;

namespace TicketPeru.Services
{
    public class UserService
    {
        public async Task<string> AgregarUsuarioABTicket(ApplicationUser applicationUser)
        {
            var parametros = new
            {
                nombre = applicationUser.Nombres,
                apellidos = applicationUser.Apellidos,
                email = applicationUser.Email,
                idTipoDocumento = "1",
                Documento = applicationUser.Documento,
                referencia = applicationUser.Id
            };

            var json = JsonConvert.SerializeObject(parametros);

            string resultado = await BTicketAPI.MakePostRequestAsync("user/add", json);
            Response response = JsonConvert.DeserializeObject<Response>(resultado);

            return response.resp;
        }

        public async Task<string> EditarUsuarioEnBTicket(ApplicationUser applicationUser)
        {
            var parametros = new
            {
                idUsuario = applicationUser.BTId,
                nombre = applicationUser.Nombres,
                apellidos = applicationUser.Apellidos,
                email = applicationUser.Email,
                idTipoDocumento = "1",
                Documento = applicationUser.Documento,
                referencia = applicationUser.Id
            };

            var json = JsonConvert.SerializeObject(parametros);

            string resultado = await BTicketAPI.MakePostRequestAsync("user/edit", json);
            Response response = JsonConvert.DeserializeObject<Response>(resultado);

            return response.resp;
        }
    }
}