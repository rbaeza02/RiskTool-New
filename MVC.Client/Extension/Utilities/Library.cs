using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.MainModule.Entities;

namespace MVC.Client.Extension.Utilities
{
    public class Library
    {
        public static bool isControllerAction(string actionName, string controllerName)
        {
            return ((List<SelectAccionUser_Result>)HttpContext.Current.Session["permisos"]).Exists(x => x.actionName == actionName && x.controllerName == controllerName);            
        }
    }
}