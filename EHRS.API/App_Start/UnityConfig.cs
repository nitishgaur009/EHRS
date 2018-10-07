using EHRS.BLL.Abstract;
using EHRS.BLL.Concrete;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;
using System.Web.Http;
using Unity;
using Unity.WebApi;

namespace EHRS.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
            section.Configure(container);

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}