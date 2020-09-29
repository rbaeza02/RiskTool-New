

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;
using Domain.MainModule.Entities;
using MVC.Client.Extension.Utilities;
using MVC.Client.Extensions.Utilities;


namespace MVC.Client.Extensions.HtmlHelpers
{
    /// <summary>
    /// Class containing custom HtmlHelpers for ASP.NET MVC.
    /// </summary>
    public static class NLayerAppHtmlHelpers
    {
        #region HtmlHelper Extension mehtods

        /// <summary>
        /// Displays the name for the selected propery by the expresion.
        /// </summary>
        /// <typeparam name="T">Type of the model.</typeparam>
        /// <typeparam name="K">Type of the selected property.</typeparam>
        /// <param name="helper">Instance of the Extended HtmlHelper class.</param>
        /// <param name="member">Lambda Expression containing the targeted member.</param>
        /// <returns>A piece of HTML to be rendered without HTML encoding it.</returns>
        public static MvcHtmlString DisplayNameFor<T, K>(this HtmlHelper<T> helper, Expression<Func<T, K>> member)
        {
            MemberExpression expression = member.Body as MemberExpression;
            if (expression == null)
            {
                throw new ArgumentException("member must be a MemberExpression", "member");
            }
            //
            return MvcHtmlString.Create(DisplayNameFor(helper.ViewData.ModelMetadata, expression.Member.Name).GetDisplayName());
        }

        /// <summary>
        /// This method gets the name used to display a property from the metadata of the model.
        /// </summary>
        /// <param name="metaData">The metadata for the property.</param>
        /// <param name="memberName">Name of the member.</param>
        /// <returns></returns>
        private static ModelMetadata DisplayNameFor(ModelMetadata metaData, string memberName)
        {

            if (metaData.PropertyName == memberName)
            {
                return metaData;
            }
            else
            {
                foreach (var property in metaData.Properties)
                {
                    ModelMetadata result = DisplayNameFor(property, memberName);
                    if (result != null)
                    {
                        return result;
                    }
                }
                //It's impossible to get here because we correcteness is enforced at compile time.
                // (A MemberExpression with an invalid name wouldn't compile).
                return null;
            }
        }

        /// <summary>
        /// Serializes the target entity as a base 64 string and creates a form hidden field for it.
        /// </summary>
        /// <typeparam name="T">Type of the entity to be serialized.</typeparam>
        /// <param name="helper">Instance of the Extended HtmlHelper class.</param>
        /// <param name="entity">The entity to be serialized as a hidden field.</param>
        /// <returns>A HTML hidden field to be rendered without HTML encoding it.</returns>
        public static MvcHtmlString SerializedHidden<T>(this HtmlHelper<T> helper, T entity)
        {
            if (entity != null)
            {
                MvcHtmlString hidden = helper.Hidden(string.Concat(typeof(T).Name, "STE"), new SelfTrackingEntityBase64Converter<T>().ToBase64(entity));
                return hidden;
            }
            return MvcHtmlString.Empty;
        }


        public static MvcHtmlString CustomValidacionMessageFor<TModel, TProperty>(this HtmlHelper<TModel> helper, Expression<Func<TModel, TProperty>> expression)
        {
            //Buscamos si esta vavio el mensaje
            if (helper.ValidationMessageFor(expression).ToString().
                Substring(helper.ValidationMessageFor(expression).ToString().LastIndexOf("</span>") - 1, 1) != ">")
            {
                TagBuilder containerDivBuilder = new TagBuilder("div");
                containerDivBuilder.AddCssClass("alert alert-error");

                TagBuilder boton = new TagBuilder("button");
                boton.Attributes.Add("type", "button");
                boton.AddCssClass("close");
                boton.Attributes.Add("data-dismiss", "alert");

                containerDivBuilder.InnerHtml += boton.ToString(TagRenderMode.Normal);
                containerDivBuilder.InnerHtml += "<strong>Error:</strong>";
                containerDivBuilder.InnerHtml += helper.ValidationMessageFor(expression).ToString();

                return MvcHtmlString.Create(containerDivBuilder.ToString(TagRenderMode.Normal));
            }
            else
                return null;
        }

        public static List<SelectPagina_Result> CompareMenu(List<SelectPagina_Result> lista, string action, string controller, string controllerPadre)
        {
            if (controllerPadre == controller)
                if (lista.Exists(x => x.controllerName == controller && x.actionName == action))
                    return lista.FindAll(x => x.ControllerContainer == controller);

            return new List<SelectPagina_Result>();
        }

        public static String SecuredActionEnabled(string actionName, string controllerName)
        {
            string html;

            if (Library.isControllerAction(actionName, controllerName))
                html = string.Empty;
            else
                html = "disabled";

            return html;
        }

        public static bool SecuredAction(string actionName, string controllerName)
        {
            return Library.isControllerAction(actionName, controllerName);            
        }
        /// <summary>
        /// Renders the action link, provided the user has access to the action method being linked to
        /// </summary>
        /// <param name="helper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <returns></returns>
        
    

        #endregion

    }
}