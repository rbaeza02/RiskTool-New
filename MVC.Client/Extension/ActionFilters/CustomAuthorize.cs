using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Domain.MainModule.Entities;


namespace MVC.Client.Extensions.ActionFilters
{
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
       
               
        public override void OnAuthorization(AuthorizationContext filterContext)
        {   
            if (!filterContext.ActionDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true) && !filterContext.ActionDescriptor.ControllerDescriptor.IsDefined(typeof(AllowAnonymousAttribute), true))
            {
                if (HttpContext.Current.Session["permisos"] == null)
                {
                    if (!IsAjax(filterContext))
                    {
                        var url = new UrlHelper(filterContext.RequestContext);
                        var loginUrl = url.Action("Login", "Account", null);
                        filterContext.Result = new RedirectResult(loginUrl);
                    }
                    //else
                    //{                        
                    //    filterContext.Result = new JsonResult
                    //    {
                    //        Data = new
                    //        {
                    //            errorAcceso = "La sesión se ha terminado"
                    //        },
                    //        JsonRequestBehavior = JsonRequestBehavior.AllowGet
                    //    };
                        
                    //}
                }
                else
                    if (!IsAjax(filterContext))
                    {                        

                        if (!((List<SelectAccionUser_Result>)HttpContext.Current.Session["permisos"]).Exists(x => x.actionName == filterContext.ActionDescriptor.ActionName && x.controllerName == filterContext.ActionDescriptor.ControllerDescriptor.ControllerName))
                        {
                            filterContext.Result = new ViewResult
                            {
                                ViewName = "AccessDenied",
                                MasterName = ""
                            };
                        }
                    }     
            }
              
        }

        //protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        //{
        //    if (filterContext.HttpContext.Request.IsAjaxRequest())
        //    {
        //        filterContext.Result = new JsonResult
        //        {
        //            Data = new
        //            {
        //                errorAcceso = "No Autorizado"
        //            },
        //            JsonRequestBehavior = JsonRequestBehavior.AllowGet
        //        };
        //    }
        //    else
        //    {
        //        base.HandleUnauthorizedRequest(filterContext);
        //    }
        //}

        
        private bool IsAjax(AuthorizationContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }
    }
}