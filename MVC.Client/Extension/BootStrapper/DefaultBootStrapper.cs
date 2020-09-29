using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using Domain.MainModule.Entities;
using Infrastructure.CrossCutting;
using MVC.Client.Extensions.CustomModelBinders;
using MVC.Client.Extensions.DependencyInjection;

namespace MVC.Client.Extensions.BootStrapper
{
    /// <summary>
    /// Default boot strapper implementation
    /// <see cref="MVC.Client.Extensions.BootStrapper.IBootStrapper"/>
    /// </summary>
    public class DefaultBootStrapper
        : IBootStrapper
    {
        #region Members

        /// <summary>
        /// Current IoC container
        /// </summary>
        IUnityContainer _currentContainer;

        #endregion

        #region Constructors

        /// <summary>
        /// Create a new instance of this boot strapper
        /// </summary>
        /// <param name="container">Default IoC container</param>
        public DefaultBootStrapper(IUnityContainer container)
        {
            if (container == (IUnityContainer)null)
                throw new ArgumentNullException("serviceFactory");

            _currentContainer = container;
        }

        #endregion

        #region IBootStrapper Members

        /// <summary>
        /// <see cref="M:MVC.Client.Extensions.BootStrapper.IBootStrapper.Boot"/>
        /// </summary>
        public void Boot()
        {
            //Register controllers into MVC infrastructure
            RegisterControllers();

            //Register new model binders
            RegisterModelBinders();

            //register factories
            SetUpDependencyInjection();
        }

        #endregion

        #region Private Methods

        private void SetUpDependencyInjection()
        {
            _currentContainer.RegisterType<IControllerActivator, IoCControllerActivator>(
                new ContainerControlledLifetimeManager());
            //_currentContainer.RegisterType<IDependencyResolver, ServiceLocatorDependencyResolver>(
            //    new ContainerControlledLifetimeManager());
            _currentContainer.RegisterType<IControllerFactory, DefaultControllerFactory>(
                new ContainerControlledLifetimeManager(),
                new InjectionConstructor(typeof(IControllerActivator)));
            ControllerBuilder.Current.SetControllerFactory(_currentContainer.Resolve<IControllerFactory>());
            //DependencyResolver.SetResolver(_currentContainer.Resolve<IDependencyResolver>());
        }

        private void RegisterModelBinders()
        {
            //Register a new model binder for customers. This model binder enables the deserialization
            //of a given customer in edit scenarios.

            //ModelBinders.Binders.Add(typeof(ClassFund), new SelfTrackingEntityModelBinder<ClassFund>());
            //ModelBinders.Binders.Add(typeof(Fund), new SelfTrackingEntityModelBinder<Fund>());
            //ModelBinders.Binders.Add(typeof(User), new SelfTrackingEntityModelBinder<User>());
            //ModelBinders.Binders.Add(typeof(Security), new SelfTrackingEntityModelBinder<Security>());

            //ModelBinders.Binders.Add(typeof(Ubicacion), new SelfTrackingEntityModelBinder<Ubicacion>());


            //Register a new model binder for customer's picture. This model binder binds the posted
            //image to a the byte array field in the CustomerPicture class.
            //ModelBinders.Binders.Add(typeof(CustomerPicture), new CustomerPictureModelBinder());
        }

        private void RegisterControllers()
        {
            //In this implementations only controllers in same assembly are registered in IoC container. If you
            // have controllers in a different assembly check this code.

            //Recover excuting assembly.
            Assembly assembly = Assembly.GetExecutingAssembly();

            //Recover all controller types in this assembly.
            IEnumerable<Type> controllers = assembly.GetExportedTypes()
                                                    .Where(x => typeof(IController).IsAssignableFrom(x));
            //Register all controllers types
            foreach (Type item in controllers)
                _currentContainer.RegisterType(item);
        }

        #endregion
    }
}
