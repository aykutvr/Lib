using Lib.Core.Web.Builders;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lib.Core.Web.Factories
{
    public class LibRazorWidgetFactory : LibWidgetBuilder
    {
        public LibRazorWidgetFactory(IHtmlHelper html) : base(html)
        {
        }

        public HtmlString TempMessageHandler()
        {
            string tempMessages = "";
            if (!htmlHelper.ViewContext.ModelState.IsValid)
            {
                tempMessages += Alert(htmlHelper.ViewContext.ModelState.Values.SelectMany(m => m.Errors.Select(s => s.ErrorMessage)).ToList(), "danger").Value;
            }
            tempMessages += Alert(htmlHelper.TempData.Where(w => w.Key.StartsWith("success")).Select(s => s.Value.ToString()).ToList(), "success").Value;
            tempMessages += Alert(htmlHelper.TempData.Where(w => w.Key.StartsWith("error")).Select(s => s.Value.ToString()).ToList(), "danger").Value;
            tempMessages += Alert(htmlHelper.TempData.Where(w => w.Key.StartsWith("warning")).Select(s => s.Value.ToString()).ToList(), "warning").Value;
            tempMessages += Alert(htmlHelper.TempData.Where(w => w.Key.StartsWith("info")).Select(s => s.Value.ToString()).ToList(), "info").Value;
            return new HtmlString(tempMessages);
        }

        public HtmlString SuccessAlert(string message)
           => Alert(new List<string> { message }, "success");
        public HtmlString ErrorAlert(string message)
            => Alert(new List<string> { message }, "danger");
        public HtmlString WarningAlert(string message)
            => Alert(new List<string> { message }, "warning");
        public HtmlString InfoAlert(string message)
            => Alert(new List<string> { message }, "info");
        public HtmlString Alert(List<string> messages, string alertType)
        {
            if (!messages.Any())
                return new HtmlString("");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<div class=\"alert alert-" + alertType + "\">");
            sb.AppendLine("<ul>");
            foreach (var message in messages)
                sb.AppendLine("<li>" + message + "</li>");
            sb.AppendLine("</ul>");
            sb.AppendLine("</div>");

            return new HtmlString(sb.ToString());
        }
    }
}
