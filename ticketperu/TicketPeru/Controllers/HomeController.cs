using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TicketPeru.Util.BTicket;
using TicketPeru.JsonModels.BTicket;
using System.Threading.Tasks;
using TicketPeru.Services;
using TicketPeru.Models;
using TicketPeru.Util.Helpers;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using TicketPeru.Util;

namespace TicketPeru.Controllers
{
    public class HomeController : Controller
    {
        protected UserManager<ApplicationUser> UserManager { get; set; }
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public HomeController()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
            this.UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.ApplicationDbContext));
        }

        public ActionResult Index(FormCollection formcollection, String Meses, Int32? TipoEvento, String Filtro)
        {
            HomeIndexViewModel homeIndexViewModel = new HomeIndexViewModel();
            var context = ApplicationDbContext.Create();
            String Buscar = formcollection["Buscar"];
            homeIndexViewModel.Buscar = Buscar;
            homeIndexViewModel.Meses = Meses;
            homeIndexViewModel.TipoEvento = TipoEvento;
            homeIndexViewModel.tipoEventos = context.TipoEventos.ToList();
            homeIndexViewModel.Filtro = Filtro;

            ViewBag.Menus = context.TipoEventos.ToList();

            if (Buscar != null && Buscar.Length > 0)
            {
                homeIndexViewModel.eventos = context.Eventos.Where(x => x.NombreEvento.Contains(Buscar)).ToList();
                homeIndexViewModel.pases = context.Pases.ToList();
            }
            else if (Meses != null && Meses.Length > 0)
            {
                var EventosTemp = context.Eventos.ToList();
                var PasesTemp = context.Pases.ToList();

                List<Models.Pase> ListaPasesFinal = new List<Models.Pase>();
                List<Models.Evento> ListaEventosFinal = new List<Models.Evento>();

                if (Meses == "ENERO-MARZO")
                {
                    foreach (var pase in PasesTemp)
                    {
                        DateTime fechaPase = Convert.ToDateTime(pase.FechaPase);

                        if (fechaPase.Month >= 1 && fechaPase.Month <= 3)
                        {
                            ListaPasesFinal.Add(pase);
                            ListaEventosFinal.Add(EventosTemp.First(x => x.ID == pase.EventoID));
                        }
                    }

                    homeIndexViewModel.pases = ListaPasesFinal.ToList();
                    homeIndexViewModel.eventos = ListaEventosFinal.ToList();
                }
                else if (Meses == "ABRIL-JUNIO")
                {
                    foreach (var pase in PasesTemp)
                    {
                        DateTime fechaPase = Convert.ToDateTime(pase.FechaPase);

                        if (fechaPase.Month >= 4 && fechaPase.Month <= 6)
                        {
                            ListaPasesFinal.Add(pase);
                            ListaEventosFinal.Add(EventosTemp.First(x => x.ID == pase.EventoID));
                        }
                    }

                    homeIndexViewModel.pases = ListaPasesFinal.ToList();
                    homeIndexViewModel.eventos = ListaEventosFinal.ToList();
                }
                else if (Meses == "JULIO-SETIEMBRE")
                {
                    foreach (var pase in PasesTemp)
                    {
                        DateTime fechaPase = Convert.ToDateTime(pase.FechaPase);

                        if (fechaPase.Month >= 7 && fechaPase.Month <= 9)
                        {
                            ListaPasesFinal.Add(pase);
                            ListaEventosFinal.Add(EventosTemp.First(x => x.ID == pase.EventoID));
                        }
                    }

                    homeIndexViewModel.pases = ListaPasesFinal.ToList();
                    homeIndexViewModel.eventos = ListaEventosFinal.ToList();
                }
                else if (Meses == "OCTUBRE-DICIEMBRE")
                {
                    foreach (var pase in PasesTemp)
                    {
                        DateTime fechaPase = Convert.ToDateTime(pase.FechaPase);

                        if (fechaPase.Month >= 10 && fechaPase.Month <= 12)
                        {
                            ListaPasesFinal.Add(pase);
                            ListaEventosFinal.Add(EventosTemp.First(x => x.ID == pase.EventoID));
                        }
                    }

                    homeIndexViewModel.pases = ListaPasesFinal.ToList();
                    homeIndexViewModel.eventos = ListaEventosFinal.Distinct().ToList();
                }
                else
                {
                    homeIndexViewModel.eventos = context.Eventos.ToList();
                    homeIndexViewModel.pases = context.Pases.ToList();
                }
            }
            else if (TipoEvento != null && TipoEvento.HasValue)
            {
                homeIndexViewModel.eventos = context.Eventos.Where(x => x.TipoEventoID == TipoEvento).ToList();
                homeIndexViewModel.pases = context.Pases.ToList();
            }
            //if (Filtro != null && Filtro.Length > 0)
            //{
            //    if (Filtro == "DESTACADOS")
            //    {
            //        homeIndexViewModel.eventos = context.Eventos.ToList();
            //        homeIndexViewModel.pases = context.Pases.Where(x => x.Destacado == ConstantHelpers.ESTADO_ACTIVO_INTEGER).ToList();
            //    }
            //    else
            //    {
            //        homeIndexViewModel.eventos = context.Eventos.ToList();
            //        homeIndexViewModel.pases = context.Pases.ToList();
            //    }
            //}
            else
            {
                homeIndexViewModel.eventos = context.Eventos.ToList();
                homeIndexViewModel.pases = context.Pases.ToList();
            }

            homeIndexViewModel.pasesDestacados = homeIndexViewModel.pases.Where(x => x.Destacado == ConstantHelpers.ESTADO_ACTIVO_INTEGER).ToList();

            return View(homeIndexViewModel);
        }

        [HttpPost]
        public async Task<String> Sync()
        {
            var syncService = new SyncService();
            try
            {
                await syncService.Sync();

                return "La base de datos se sincronizó correctamente";
            }
            catch (Exception e)
            {
                //LOG ERROR
                return "Error al sincronizar - " + e.Message;
            }
        }

        public async Task<ActionResult> EventDetail(Int32 PaseId)
        {
            EventDetailViewModel eventDetailViewModel = new EventDetailViewModel();
            RecintoService recintoService = new RecintoService();
            PaseService paseService = new PaseService();

            var context = this.ApplicationDbContext;
            ViewBag.Menus = context.TipoEventos.ToList();
            var resultado = context.Pases.Find(PaseId);





           List<JsonModels.BTicket.Evento> bTicketEventos;

            try
            {
                bTicketEventos = await paseService.getEventos(ConstantHelpers.IDIOMA_API);
            }
            catch (Exception e)
            {
                throw e;
            }

            foreach (JsonModels.BTicket.Evento bTicketEvento in bTicketEventos.Where(e=>e.idEvento== resultado.EventoID))
            {
                foreach (JsonModels.BTicket.Pase bTicketPase in bTicketEvento.Pases)
                {
                    //var ticketPeruPase = context.Pases.SingleOrDefault(x => x.BTPaseID == bTicketPase.idPase);

                    //List<JsonModels.BTicket.Recinto> bTicketRecintos = await recintoService.getZonasSectores(resultado.RecintoID, ConstantHelpers.IDIOMA_API);
                    //JsonModels.BTicket.Recinto bTicketRecinto = bTicketRecintos.Find(x => x.idRecinto == resultado.RecintoID);
             
                    double precioMinimo = ConstantHelpers.PRECIO_PRODUCTO_TOPE;
                    foreach (JsonModels.BTicket.Producto bTicketPorducto in bTicketPase.Productos)
                    {
                        if (bTicketPorducto.precio < precioMinimo)
                        {
                            precioMinimo = bTicketPorducto.precio;
                        }
                    }
                    eventDetailViewModel.ListProductos = bTicketPase.Productos;

                    //ticketPeruPase.PrecioMinimo = precioMinimo;
                }
            }




            eventDetailViewModel.paseActual = context.Pases.Find(PaseId);
            eventDetailViewModel.eventoActual = context.Eventos.Find(eventDetailViewModel.paseActual.EventoID);

            return View(eventDetailViewModel);
        }

        [Authorize]
        public async Task<ActionResult> Purchase(Int32 TicketPeruPaseId)
        {
            var context = this.ApplicationDbContext;

            var paseActual = context.Pases.Find(TicketPeruPaseId);
            var eventoActual = context.Eventos.Find(paseActual.EventoID);

            int bTicketPaseId = paseActual.BTPaseID;
            int btTicketEventoId = eventoActual.BTEventoID;


            VentaService ventaService = new VentaService();
            var user = UserManager.FindById(User.Identity.GetUserId());

            string ventaBticketURL;
            if (user != null)
            {
                try
                {
                    ventaBticketURL = await ventaService.obtenerUrlVentaDeBTicket(int.Parse(user.BTId), user.Id, bTicketPaseId, btTicketEventoId, ConstantHelpers.IDIOMA_API);
                    return Redirect(ventaBticketURL);
                }
                catch 
                {
                    //Mandar mensaje de error;
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }

        [Authorize]
        public async Task<ActionResult> MyPurchases()
        {
            VentaService ventaService = new VentaService();
            var user = UserManager.FindById(User.Identity.GetUserId());

            string misComprasURL;

            try
            {
                misComprasURL = await ventaService.obtenerUrlMisComprasDeBTicket(int.Parse(user.BTId), user.Id, ConstantHelpers.IDIOMA_API);
                return Redirect(misComprasURL);
            }
            catch 
            {
                //Mandar mensaje de error;
                return RedirectToAction("Index", "Home");
            }

        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Preguntas()
        {
            return View();
        }

        public ActionResult Terminos()
        {
            return View();
        }

        public ActionResult Contact(String Message,int Estado=0)
        {
            ContactViewModel contactViewModel = new ContactViewModel();
            var context = this.ApplicationDbContext;
            if (Estado == 1)
            {
                ViewBag.Status = 1;
            }
            else { ViewBag.Status = 0; }
            ViewBag.Menus = context.TipoEventos.ToList();
            contactViewModel.tipoEventos = context.TipoEventos.ToList();
            ViewBag.StatusMessage = Message;
            return View(contactViewModel);
        }
 

        [HttpPost]
        public ActionResult Contact(ContactViewModel model)
        {
            var context = this.ApplicationDbContext;
            var emailLogic = new EmailHelpers();
            Boolean Repuesta = emailLogic.SendContactEmail(model.NombreEvento, model.Local, model.TipoEvento, model.FechaEvento, model.NombreSolicitante, model.CorreoSolicitante, model.TelefonoSolicitante, model.ComentarioSolicitante);

            if (Repuesta)
            {
                ViewBag.StatusMessage = "Su solicitud fue enviada correctamente.";
                ViewBag.Status = 1;
                return RedirectToAction("Contact", new { Message = ViewBag.StatusMessage,Estado=1 });
            }
            else
            {
                ViewBag.Menus = context.TipoEventos.ToList();
                ViewBag.StatusMessage = "Ocurrio un error al guardar el registro.";
                ViewBag.Status = 0;
                model.tipoEventos= context.TipoEventos.ToList();
                return View(model);
            }
        }

        public ActionResult Claim(String Message)
        {
            ClaimViewModel claimViewModel = new ClaimViewModel();
            var context = this.ApplicationDbContext;

            ViewBag.StatusMessage = Message;
            return View(claimViewModel);
        }

        [HttpPost]
        public ActionResult Claim(ClaimViewModel model)
        {
            var emailLogic = new EmailHelpers();
            Boolean Repuesta = emailLogic.SendClaimEmail(model.Nombres, model.Apellidos, model.DNI, model.Email, model.Telefono, model.Direccion, model.Incidencia, model.Tipo, model.DescripcionTipo, model.DescripcionReclamo);

            if (Repuesta)
            {
                ViewBag.StatusMessage = "Su solicitud fue enviada correctamente.";
                return RedirectToAction("Claim", new { Message = ViewBag.StatusMessage });
            }
            else
            {
                return View(model);
            }
        }



        public ActionResult Mensajes(String Message)
        {
            MensajeViewModel claimViewModel = new MensajeViewModel();
            var context = this.ApplicationDbContext;

            ViewBag.StatusMessage = Message;
            return View(claimViewModel);
        }

        [HttpPost]
        public ActionResult Mensajes(MensajeViewModel model)
        {
            var emailLogic = new EmailHelpers();
            Boolean Repuesta = emailLogic.SendMensajeEmail(model.Nombres, model.Apellidos, model.Email, model.Empresa, model.Departamento, model.Mensaje);

            if (Repuesta)
            {
                ViewBag.StatusMessage = "Su solicitud fue enviada correctamente.";
                return RedirectToAction("Mensajes", new { Message = ViewBag.StatusMessage });
            }
            else
            {
                return View(model);
            }
        }

        public ActionResult ErrorPage()
        {
            return View();
        }
    }
}