using AutoMapper;
using EHRS.API.ViewModels;
using EHRS.BLL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;
using Unity.WebApi;

namespace EHRS.API
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
           GlobalConfiguration.Configure(WebApiConfig.Register);
           UnityConfig.RegisterComponents();

            Mapper.Initialize(cfg => {
                cfg.CreateMap<LoginViewModel, LoginModel>();
                cfg.CreateMap<LoginModel, LoginViewModel>();
                cfg.CreateMap<UserAuthDataViewModel, UserDataModel>();
                cfg.CreateMap<UserDataModel, UserAuthDataViewModel>();
            });
        }
    }
}
