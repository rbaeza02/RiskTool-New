

using System;
using System.Web.Mvc;
using Domain.Core.Entities;
using MVC.Client.Extensions.Utilities;

namespace MVC.Client.Extensions.CustomModelBinders
{

    /// <summary>
    /// Custom model binder for self-tracking entities
    /// </summary>
    /// <typeparam name="T">Type of the Self-Tracking entity to be binded</typeparam>
    public class SelfTrackingEntityModelBinder<T> : DefaultModelBinder where T : class, IObjectWithChangeTracker
    {
        #region DefaultModelBinder overrides

        /// <summary>
        /// Creates a new instance of the class or deserialize an existing one if its present in the request
        /// </summary>
        /// <param name="controllerContext">The context within which the controller operates. The context information includes the controller, HTTP content, request context, and route data.</param>
        /// <param name="bindingContext">The context within which the model is bound. The context includes information such as the model object, model name, model type, property filter, and value provider.</param>
        /// <param name="modelType">The type of the model object to return.</param>
        /// <returns>A data object of the specified type.</returns>
        protected override object CreateModel(ControllerContext controllerContext, ModelBindingContext bindingContext, Type modelType)
        {
            // Get the name of the request value by convention
            string steName = typeof(T).Name+"STE";
            // Check if the request contains a value for that prefix and deserialize the entity, otherwise fallback to default behavior
            if(bindingContext.ValueProvider.ContainsPrefix(steName)){
                var value = bindingContext.ValueProvider.GetValue(steName);
                return new SelfTrackingEntityBase64Converter<T>().ToEntity(value.AttemptedValue);
            }
            return base.CreateModel(controllerContext, bindingContext, modelType);
        }

        #endregion
    }
}