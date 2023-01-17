using DsiCodeTech.SuPlazaWeb.Contabilidad.Dto;
using DsiCodeTech.SuPlazaWeb.Contabilidad.Handler.ExceptionHandler;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Cors;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Security.Claims;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SeguridadController : Controller
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        public ActionResult Login([Bind(Include = "User_name,Password")] UsuarioDto usuarioDto, string returnUrl) 
        {
            if (ModelState.IsValid)
            {

                RedirectToAction("Login","Seguridad");
            }
            return View();
        }


        #region Metodo SigIn
        private ActionResult SigInUser(UsuarioDto usuarioDto, bool recuerdame, string returnUrl)
        {
            ActionResult Result;
            //un claims puede almacenar cualquier tipo de informacion del usuario, nombre, mail, password, lo que sea
            List<Claim> Claims = new List<Claim>(); //listado de claims
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, usuarioDto.User_name)); //primer claims
            Claims.Add(new Claim(ClaimTypes.Name, usuarioDto.User_name));
            ///estos claims se almacenan en la cookie para identificar al usuario y sus atributos o permisos
            var Identity = new ClaimsIdentity(Claims, DefaultAuthenticationTypes.ApplicationCookie); 
            ///cuando el usuario se logea se crea una cookie de autenticacion 
           ///este AutenticationManager se encarga de administrarla cookie y da el seguimiento a todo el sitio con todo y los permisos del usuario
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignIn(new AuthenticationProperties() { IsPersistent = recuerdame }, Identity); //el rememberMe es para recordarlo true/false

            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Url.Action("mostrar", "Contabilidad");
            }
            Result = Redirect(returnUrl);
            return Result;

        }
        #endregion

    }
}