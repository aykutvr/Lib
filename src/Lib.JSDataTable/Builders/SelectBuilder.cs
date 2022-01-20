using Microsoft.AspNetCore.Html;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.Encodings.Web;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents the select xtension builder
    /// </summary>
    public class SelectBuilder : IJToken
    {
        SelectOptions select;

        /// <summary>
        /// Initialize a new instance of <see cref="SelectBuilder"/>
        /// </summary>
        public SelectBuilder()
        {
            select = new SelectOptions();
        }

        /// <summary>
        /// Indicate if the selected items will be removed when clicking outside of the table
        /// </summary>
        /// <param name="blurable"></param>
        /// <returns></returns>
        public SelectBuilder Blurable(bool blurable)
        {
            select.Blurable = blurable;
            return this;
        }

        /// <summary>
        /// Set the class name that will be applied to selected items
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public SelectBuilder ClassName(string className)
        {
            select.ClassName = className;
            return this;
        }

        /// <summary>
        /// Enable / disable the display for item selection information in the table summary.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public SelectBuilder Info(bool info)
        {
            select.Info = info;
            return this;
        }

        /// <summary>
        /// Set which table items to select (rows, columns or cells)
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public SelectBuilder Items(SelectItemsType items)
        {
            select.Items = items;
            return this;
        }

        /// <summary>
        /// Set the selection style for end user interaction with the table.
        /// </summary>
        /// <param name="style"></param>
        /// <returns></returns>
        public SelectBuilder Style(SelectStyle style)
        {
            select.Style = style;
            return this;
        }

        /// <summary>
        /// Set the element selector used for mouse event capture to select items. 
        /// </summary>
        /// <param name="selector"></param>
        /// <returns></returns>
        public SelectBuilder Selector(string selector)
        {
            select.Selector = selector;
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JObject jObject = new JObject();
            if (select.Style == SelectStyle.MultiShift)
            {
                jObject.Add("style", new JValue("multi+shift"));
            }
            else
            {
                jObject.Add("style", new JValue(select.Style.ToString().ToLower()));
            }
            if (select.Blurable) jObject.Add("blurable", new JValue(true));
            if (!string.IsNullOrEmpty(select.ClassName)) jObject.Add("className", new JValue(select.ClassName));
            if (!select.Info) jObject.Add("info", new JValue(false));
            if (select.Items != SelectItemsType.Row) jObject.Add("items", new JValue(select.Items.ToString().ToLower()));
            if (!string.IsNullOrEmpty(select.Selector)) jObject.Add("selector", new JValue(select.Selector));
            return jObject;
        }
    }
}
