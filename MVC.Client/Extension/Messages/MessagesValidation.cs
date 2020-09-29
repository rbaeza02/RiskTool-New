using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace MVC.Client.Extension.Messages
{
    public static class MessagesValidation
    {
        public static StringBuilder Error(String message)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<div class='alert alert-danger'>");
            html.Append("<button type='button' class='close' data-dismiss='alert'><span class='fui-cross'></span></button>");
            html.Append("<strong>Error: </strong>");
            html.Append(message);
            html.Append("</div>");

            return html;
        }

        public static StringBuilder Successful(String message)
        {
            StringBuilder html = new StringBuilder();

            html.Append("<div class='alert alert-success'>");
            html.Append("<button type='button' class='close' data-dismiss='alert'><span class='fui-cross'></span></button>");
            //html.Append("<strong>Error: </strong>");
            html.Append(message);
            html.Append("</div>");

            return html;
        }
    }
}