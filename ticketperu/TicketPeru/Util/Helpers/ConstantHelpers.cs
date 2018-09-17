using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TicketPeru.Util.Helpers
{
    public static class ConstantHelpers
    {
        public const Int32 IDIOMA_API = 1;

        public const String ESTADO_INACTIVO = "0";
        public const String ESTADO_ACTIVO = "1";

        public const Int32 ESTADO_INACTIVO_INTEGER = 0;
        public const Int32 ESTADO_ACTIVO_INTEGER = 1;

        public const Int32 ESTADO_EVENTO_PROXIMO = 0;
        public const Int32 ESTADO_EVENTO_VENTA = 1;

        public const Double PRECIO_PRODUCTO_TOPE = 10000;

        public const String CORREO_ADMINISTRADOR = "admin@ticketperu.pe";
        public const String CORREO_SERVIDOR_USUARIO = "webticketperu@gmail.com";
        public const String CORREO_SERVIDOR_CLAVE = "Webticketperu2018";

        public static class Layout
        {
            public static readonly String MODAL_EMAIL_PATH = "~/Views/Shared/_MailLayout.cshtml";
        }
    }
}