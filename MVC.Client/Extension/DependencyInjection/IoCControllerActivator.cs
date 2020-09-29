using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.Practices.ServiceLocation;

namespace MVC.Client.Extensions.DependencyInjection
{
    public class IoCControllerActivator : IControllerActivator
    {
        private readonly IServiceLocator _serviceLocator;

        public IoCControllerActivator(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            return _serviceLocator.GetInstance(controllerType) as IController;
        }
    }
}
