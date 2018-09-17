using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using TicketPeru.Models;
using TicketPeru.Services;

namespace TicketPeru.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private ApplicationUserManager _userManager;

        public UserController()
        {
        }

        public UserController(ApplicationUserManager userManager)
        {
            UserManager = userManager;
        }

        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        // GET: User/Edit
        public async Task<ActionResult> Edit()
        {
            var id = User.Identity.GetUserId();

            ApplicationUser applicationUser = new ApplicationUser();
            applicationUser = await UserManager.FindByIdAsync(id);

            EditUserViewModel user = new EditUserViewModel();
            user.Nombres = applicationUser.Nombres;
            user.Apellidos = applicationUser.Apellidos;
            user.Documento = applicationUser.Documento;

            return View(user);
        }

        // POST: User/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditUserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            try
            {
                var id = User.Identity.GetUserId();

                var store = new UserStore<ApplicationUser>(new ApplicationDbContext());
                var manager = new UserManager<ApplicationUser>(store);
                var userService = new UserService();
                var currentUser = await manager.FindByIdAsync(id);

                currentUser.Nombres = user.Nombres;
                currentUser.Apellidos = user.Apellidos;
                currentUser.Documento = user.Documento;

                await manager.UpdateAsync(currentUser);
                await userService.EditarUsuarioEnBTicket(currentUser);

                ViewBag.StatusMessage = "Los datos fueron actualizados correctamente.";
                return View();
            }
            catch
            {
                return View();
            }
        }
    }
}
