using DsiCodetech.SuPlazaWeb.Business;
using DsiCodetech.SuPlazaWeb.Business.Interface;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure;
using DsiCodeTech.SuPlazaWeb.Repository.Infraestructure.Contract;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.WebApi;

namespace DsiCodeTech.SuPlazaWeb.Contabilidad
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            container.RegisterType<IUnitOfWork, UnitOfWork>();
            // e.g. container.RegisterType<ITestService, TestService>();
            container.RegisterType<IArticuloBusiness, ArticuloBusiness>();
            
            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}