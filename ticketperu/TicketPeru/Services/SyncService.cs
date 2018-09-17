using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using TicketPeru.Models;
using TicketPeru.Util.Helpers;

namespace TicketPeru.Services
{
    public class SyncService
    {
        protected ApplicationDbContext ApplicationDbContext { get; set; }

        public SyncService()
        {
            this.ApplicationDbContext = new ApplicationDbContext();
        }

        public async Task<bool> Sync()
        {
            PaseService paseService = new PaseService();
            ComunService comunService = new ComunService();
            RecintoService recintoService = new RecintoService();

            var context = this.ApplicationDbContext;

            //---------------------Sincro Categoría--------------------//

            //Insercion y actualizacion de Categorias del Json
            List<JsonModels.BTicket.TipoEvento> bTicketTipoEventos;
            try
            {
                bTicketTipoEventos = await comunService.getTipoEvento(ConstantHelpers.IDIOMA_API);                
            }
            catch (Exception e)
            {
                throw e;
            }

            foreach (JsonModels.BTicket.TipoEvento bTicketTipoEvento in bTicketTipoEventos)
            {
                var ticketPeruTipoEvento = context.TipoEventos.SingleOrDefault(x => x.BTTipoEventoID == bTicketTipoEvento.IdTipoEvento);
                if (ticketPeruTipoEvento != null)
                {
                    ticketPeruTipoEvento.Descripcion = bTicketTipoEvento.Descripcion;
                    ticketPeruTipoEvento.IdiomaID = bTicketTipoEvento.idIdioma;

                    context.SaveChanges();
                }
                else
                {
                    ticketPeruTipoEvento = new Models.TipoEvento();
                    ticketPeruTipoEvento.BTTipoEventoID = bTicketTipoEvento.IdTipoEvento;
                    ticketPeruTipoEvento.Descripcion = bTicketTipoEvento.Descripcion;
                    ticketPeruTipoEvento.IdiomaID = bTicketTipoEvento.idIdioma;

                    context.TipoEventos.Add(ticketPeruTipoEvento);
                    context.SaveChanges();
                }
            }
            
            //Borrado de registros no encontrados en el Json
            List<Models.TipoEvento> ticketPeruTipoEventos = context.TipoEventos.ToList();
            List<Models.TipoEvento> ticketPeruTipoEventosToDelete = new List<TipoEvento>();

            foreach (Models.TipoEvento ticketPeruTipoEvento in ticketPeruTipoEventos)
            {
                var bTicketTipoEvento = bTicketTipoEventos.Find(x => x.IdTipoEvento == ticketPeruTipoEvento.BTTipoEventoID);
                if(bTicketTipoEvento == null)
                {
                    ticketPeruTipoEventosToDelete.Add(ticketPeruTipoEvento);    
                }
            }
            foreach (Models.TipoEvento ticketPeruTipoEventoToDelete in ticketPeruTipoEventosToDelete)
            {
                context.TipoEventos.Remove(ticketPeruTipoEventoToDelete);
                context.SaveChanges();
            }


            //------------- Sincro Eventos y Pases ------------------//

            //Insercion y actualizacion de Eventos y Pases del Json
            List<JsonModels.BTicket.Evento> bTicketEventos;
            try
            {
                bTicketEventos = await paseService.getEventos(ConstantHelpers.IDIOMA_API);
            }
            catch(Exception e)
            {
                throw e;
            }
            
            //Eventos
            foreach (JsonModels.BTicket.Evento bTicketEvento in bTicketEventos)
            {
                var ticketPeruEvento = context.Eventos.SingleOrDefault(x => x.BTEventoID == bTicketEvento.idEvento);
                if (ticketPeruEvento != null)
                {
                    ticketPeruEvento.NombreEvento = bTicketEvento.NombreEvento;
                    ticketPeruEvento.DescripcionEvento = bTicketEvento.DescripcionEvento;
                    ticketPeruEvento.DescripcionLargaEvento = bTicketEvento.DescripcionLargaEvento;
                    ticketPeruEvento.TipoEventoID = bTicketEvento.idTipoEvento;
                    ticketPeruEvento.EstadoEvento = bTicketEvento.EstadoEvento;
                    ticketPeruEvento.DescripcionEstadoEvento = bTicketEvento.DescripicionEstadoEvento;
                    ticketPeruEvento.CodigoExtra = bTicketEvento.CodigoExtra;
                    ticketPeruEvento.Imagen = bTicketEvento.imagen;
                    ticketPeruEvento.ImagenMini = bTicketEvento.imagen_mini;
                    ticketPeruEvento.ImagenMedia = bTicketEvento.imagen_media;

                    context.SaveChanges();
                }
                else
                {
                    ticketPeruEvento = new Models.Evento();
                    ticketPeruEvento.BTEventoID = bTicketEvento.idEvento;
                    ticketPeruEvento.NombreEvento = bTicketEvento.NombreEvento;
                    ticketPeruEvento.DescripcionEvento = bTicketEvento.DescripcionEvento;
                    ticketPeruEvento.DescripcionLargaEvento = bTicketEvento.DescripcionLargaEvento;
                    ticketPeruEvento.TipoEventoID = bTicketEvento.idTipoEvento;
                    ticketPeruEvento.EstadoEvento = bTicketEvento.EstadoEvento;
                    ticketPeruEvento.DescripcionEstadoEvento = bTicketEvento.DescripicionEstadoEvento;
                    ticketPeruEvento.CodigoExtra = bTicketEvento.CodigoExtra;
                    ticketPeruEvento.Imagen = bTicketEvento.imagen;
                    ticketPeruEvento.ImagenMini = bTicketEvento.imagen_mini;
                    ticketPeruEvento.ImagenMedia = bTicketEvento.imagen_media;

                    context.Eventos.Add(ticketPeruEvento);
                    context.SaveChanges();
                }
                //Pases
                foreach (JsonModels.BTicket.Pase bTicketPase in bTicketEvento.Pases)
                {
                    var ticketPeruPase = context.Pases.SingleOrDefault(x => x.BTPaseID == bTicketPase.idPase);

                    if (ticketPeruPase != null)
                    {
                        ticketPeruPase.NombrePase = bTicketPase.nombrePase;
                        ticketPeruPase.DescripcionPase = bTicketPase.descripcionPase;
                        ticketPeruPase.DescripcionLargaPase = bTicketPase.descripcionLargaPase;
                        ticketPeruPase.RecintoID = bTicketPase.idRecinto;
                        ticketPeruPase.EstadoPase = bTicketPase.EstadoPase;
                        ticketPeruPase.DescripcionEstadoPase = bTicketPase.DescripicionEstadoPase;
                        ticketPeruPase.FechaPase = bTicketPase.fechaPase;
                        ticketPeruPase.FechaPorConfirmar = bTicketPase.fechaPorConfirmar;
                        ticketPeruPase.Imagen = bTicketPase.imagen;
                        ticketPeruPase.ImagenMini = bTicketPase.imagen_mini;
                        ticketPeruPase.ImagenMedia = bTicketPase.imagen_media;
                        ticketPeruPase.Destacado = bTicketPase.destacado;

                        List<JsonModels.BTicket.Recinto> bTicketRecintos = await recintoService.getZonasSectores(bTicketPase.idRecinto, ConstantHelpers.IDIOMA_API);
                        JsonModels.BTicket.Recinto bTicketRecinto = bTicketRecintos.Find(x => x.idRecinto == bTicketPase.idRecinto);
                        ticketPeruPase.NombreRecinto = bTicketRecinto.nombreRecinto;

                        double precioMinimo = ConstantHelpers.PRECIO_PRODUCTO_TOPE;
                        foreach (JsonModels.BTicket.Producto bTicketPorducto in bTicketPase.Productos)
                        {
                            if (bTicketPorducto.precio < precioMinimo)
                            {
                                precioMinimo = bTicketPorducto.precio;
                            }
                        }
                        ticketPeruPase.PrecioMinimo = precioMinimo;

                        context.SaveChanges();
                    }
                    else
                    {
                        ticketPeruPase = new Models.Pase();
                        ticketPeruPase.BTPaseID = bTicketPase.idPase;
                        ticketPeruPase.NombrePase = bTicketPase.nombrePase;
                        ticketPeruPase.DescripcionPase = bTicketPase.descripcionPase;
                        ticketPeruPase.DescripcionLargaPase = bTicketPase.descripcionLargaPase;
                        ticketPeruPase.RecintoID = bTicketPase.idRecinto;
                        ticketPeruPase.EstadoPase = bTicketPase.EstadoPase;
                        ticketPeruPase.DescripcionEstadoPase = bTicketPase.DescripicionEstadoPase;
                        ticketPeruPase.FechaPase = bTicketPase.fechaPase;
                        ticketPeruPase.FechaPorConfirmar = bTicketPase.fechaPorConfirmar;
                        ticketPeruPase.Imagen = bTicketPase.imagen;
                        ticketPeruPase.ImagenMini = bTicketPase.imagen_mini;
                        ticketPeruPase.ImagenMedia = bTicketPase.imagen_media;
                        ticketPeruPase.Destacado = bTicketPase.destacado;

                        ticketPeruPase.EventoID = ticketPeruEvento.ID;

                        List<JsonModels.BTicket.Recinto> bTicketRecintos = await recintoService.getZonasSectores(bTicketPase.idRecinto, ConstantHelpers.IDIOMA_API);
                        JsonModels.BTicket.Recinto bTicketRecinto = bTicketRecintos.Find(x => x.idRecinto == bTicketPase.idRecinto);
                        ticketPeruPase.NombreRecinto = bTicketRecinto.nombreRecinto;

                        double precioMinimo = ConstantHelpers.PRECIO_PRODUCTO_TOPE;
                        foreach (JsonModels.BTicket.Producto bTicketPorducto in bTicketPase.Productos)
                        {
                            if (bTicketPorducto.precio < precioMinimo)
                            {
                                precioMinimo = bTicketPorducto.precio;
                            }
                        }
                        ticketPeruPase.PrecioMinimo = precioMinimo;

                        context.Pases.Add(ticketPeruPase);
                        context.SaveChanges();
                    }
                }
            }

            //Borrado de registros no encontrados en el Json
            List<Models.Evento> ticketPeruEventos = context.Eventos.ToList();
            List<Models.Evento> ticketPeruEventosToDelete = new List<Evento>();

            foreach (Models.Evento ticketPeruEvento in ticketPeruEventos)
            {
                var bTicketEvento = bTicketEventos.Find(x => x.idEvento == ticketPeruEvento.BTEventoID);                
                if (bTicketEvento == null) //Si no hay evento, se borran todos sus pases y luego el evento.
                {
                    List<Pase> ticketPeruPasesToDelete = new List<Pase>();
                    foreach (Models.Pase ticketPeruPase in ticketPeruEvento.Pases)
                    {
                        ticketPeruPasesToDelete.Add(ticketPeruPase);
                    }
                    foreach (Models.Pase ticketPeruPaseToDelete in ticketPeruPasesToDelete)
                    {
                        context.Pases.Remove(ticketPeruPaseToDelete);
                        context.SaveChanges();
                    }

                    ticketPeruEventosToDelete.Add(ticketPeruEvento);
                }
                else   //Si el evento existe se itera sobre sus pases
                {
                    List<Pase> ticketPeruPasesToDelete = new List<Pase>();
                    foreach (Models.Pase ticketPeruPase in ticketPeruEvento.Pases)
                    {
                        var bTicketPasesDeEvento = bTicketEvento.Pases.ToList();
                        var bTicketPaseDeEvento = bTicketPasesDeEvento.Find(x => x.idPase == ticketPeruPase.BTPaseID);

                        if (bTicketPaseDeEvento == null) //Si no hay pase, se borra de bd
                        {
                            ticketPeruPasesToDelete.Add(ticketPeruPase);
                        }
                    }
                    foreach (Models.Pase ticketPeruPaseToDelete in ticketPeruPasesToDelete)
                    {
                        context.Pases.Remove(ticketPeruPaseToDelete);
                        context.SaveChanges();
                    }
                }
            }

            foreach (Models.Evento ticketPeruEventoToDelete in ticketPeruEventosToDelete)
            {
                context.Eventos.Remove(ticketPeruEventoToDelete);
                context.SaveChanges();
            }

            return true;
        }
    }
}