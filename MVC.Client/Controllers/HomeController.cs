using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Application.MainModule.Catalogos;
using Application.MainModule.Cotizaciones;
using MVC.Client.Extensions.ActionFilters;
//using Microsoft.Reporting.WebForms;

namespace MVC.Client.Controllers
{

    [Authorize]
    [HandleCustomError]
    public class HomeController : Controller
    {
        private ICotizacionManagementService _CotizacionService;

        public HomeController(ICotizacionManagementService cotizacionService)
        {
            _CotizacionService = cotizacionService;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            //User.Identity.Name

            //var authCookie = Request.Cookies[System.Web.Security.FormsAuthentication.FormsCookieName];
            //if (authCookie != null && authCookie.Value != null)
            //{
            //    System.Web.Security.FormsAuthenticationTicket authTicket = System.Web.Security.FormsAuthentication.Decrypt(authCookie.Value);
            //    var a = Newtonsoft.Json.JsonConvert.DeserializeObject<Domain.MainModule.Entities.CustomPrincipalSerializeModel>(authTicket.UserData);
            //}
            //var a = MVC.Client.Extension.Utilities.Helper.GetUserData();


            ViewBag.Message = "Your application description page.";

            return View();
        }

       
    }
}