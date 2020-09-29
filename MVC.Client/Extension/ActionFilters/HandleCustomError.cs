using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MVC.Client.Extensions.ActionFilters
{
    public class HandleCustomError : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            if (filterContext.ExceptionHandled)
            {
                return;
            }

            // if the request is AJAX return JSON else view.
            if (IsAjax(filterContext))
            {
                //Because its a exception raised after ajax invocation
                //Lets return Json
                filterContext.Result = new JsonResult()
                {
                    Data = new { errorException = filterContext.Exception.Message },
                    JsonRequestBehavior = JsonRequestBehavior.AllowGet
                };

                filterContext.ExceptionHandled = true;
                filterContext.HttpContext.Response.Clear();
            }
            else
            {
                //Normal Exception
                //So let it handle by its default ways.
                //base.OnException(filterContext);
                //filterContext.Result = new ViewResult()
                //{
                //    ViewName = "Error"
                //};

                var controllerName = (string)filterContext.RouteData.Values["controller"];
                var actionName = (string)filterContext.RouteData.Values["action"];
                var model = new HandleErrorInfo(filterContext.Exception, controllerName, actionName);

                //filterContext.Result = new ViewResult()
                //{
                //    ViewName = actionName,
                //    TempData = filterContext.Controller.TempData,
                //    ViewData = new ViewDataDictionary(filterContext.HttpContext.Request.Params)
                //};

                filterContext.Result = new ViewResult
                {
                    ViewName = View,
                    MasterName = Master,
                    ViewData = new ViewDataDictionary(model)//,
                    //TempData = filterContext.Controller.TempData
                };

                
                
                
                //string redirectOnSuccess = filterContext.HttpContext.Request.Url.PathAndQuery;
                
                //filterContext.Result = new RedirectResult(redirectOnSuccess);

                //string parameters = filterContext.HttpContext.Request.Params;
                //send them off to the login page
                //string redirectUrl = string.Format("?ReturnUrl={0}", redirectOnSuccess);

                //var redirectResult = filterContext.Result as RedirectToRouteResult;
                //var query = filterContext.HttpContext.Request.Form;
                //// Remark: here you could decide if you want to propagate all
                //// query string values or a particular one. In my example I am
                //// propagating all query string values that are not already part of
                //// the route values
                //foreach (string key in query.Keys)
                //{
                //    if (!redirectResult.RouteValues.ContainsKey(key))
                //    {
                //        redirectResult.RouteValues.Add(key, query[key]);
                //    }
                //}

                //filterContext.HttpContext.Response.Redirect(redirectOnSuccess);
                //filterContext.HttpContext.Response.
                //filterContext.Controller.ViewData.Model = 

            }

            // Write error logging code here.

            //if want to get different of the request
            //var currentController = (string)filterContext.RouteData.Values["controller"];
            //var currentActionName = (string)filterContext.RouteData.Values["action"];


            //Make sure that we mark the exception as handled

            Application.MainModule.Utils.Log.WriteLog(ConfigurationManager.AppSettings["errorFile"], filterContext.Exception.ToString());
            filterContext.ExceptionHandled = true;
        }

        private bool IsAjax(ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.Headers["X-Requested-With"] == "XMLHttpRequest";
        }

    }


   
}