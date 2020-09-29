using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting.IoC;
using Microsoft.Practices.Unity;
using MVC.Client.Extension.Utilities;
using MVC.Client.Extensions.BootStrapper;
using Newtonsoft.Json;

namespace MVC.Client
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            //Perform application configuration
            IBootStrapper bootStrapper = new DefaultBootStrapper(GetContainer());
            bootStrapper.Boot();


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //ModelBinders.Binders.Add(typeof(DateTime?), new MyDateTimeModelBinder());
            //ModelBinders.Binders.Add(typeof(DateTime), new MyDateTimeModelBinder());
            ModelBinders.Binders.Add(typeof(double?), new DoubleModelBinder());

            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));
        }

        private IUnityContainer GetContainer()
        {
            return IoCFactory.Instance.CurrentContainer.Resolve(typeof(IUnityContainer)) as IUnityContainer;
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = Request.Cookies[FormsAuthentication.FormsCookieName];
            if (authCookie != null)
            {

                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                CustomPrincipalSerializeModel serializeModel = JsonConvert.DeserializeObject<CustomPrincipalSerializeModel>(authTicket.UserData);
                Usuario newUser = new Usuario(authTicket.Name);
                newUser.UsuarioID = serializeModel.UserId;
                newUser.NombreUsuario = serializeModel.UserName;                

                HttpContext.Current.User = newUser;
            }

        }
    }
}
