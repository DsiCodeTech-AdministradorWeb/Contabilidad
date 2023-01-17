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
using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Domain;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad.Controllers
{
    [SuPlazaExceptionFilter]
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class SeguridadController : Controller
    {
        private static readonly Logger loggerdb = LogManager.GetLogger("databaseLogger");
        private readonly IUsuarioBusiness usuarioBusiness;
        public SeguridadController(IUsuarioBusiness _usuarioBusiness)
        {
            usuarioBusiness = _usuarioBusiness;
        }
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
                ActionResult result;
                var usuario = AutoMapper.Mapper.Map<UsuarioDM>(usuarioDto);
                var usuarioDM = usuarioBusiness.ValidarUsuario(usuario);
                if (usuarioDM != null)
                {
                    //Asignamos todos los permisos de usuario a los claims
                    result = SigInUser(usuarioDM, true, returnUrl);
                    return result;
                }
                else
                {
                    return View();
                }

            }

            return View();
        }


        public ActionResult LogOff()
        {
            IAuthenticationManager authenticationManager = HttpContext.GetOwinContext().Authentication;
            authenticationManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);

            return RedirectToAction("Login", "Seguridad");
        }

        #region Metodo SigIn
        private ActionResult SigInUser(UsuarioDM usuarioDM, bool recuerdame, string returnUrl)
        {
            ActionResult Result;
            //un claims puede almacenar cualquier tipo de informacion del usuario, nombre, mail, password, lo que sea
            List<Claim> Claims = new List<Claim>(); //listado de claims
            Claims.Add(new Claim(ClaimTypes.NameIdentifier, usuarioDM.User_name)); //primer claims
            Claims.Add(new Claim(ClaimTypes.Name, usuarioDM.User_name));
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