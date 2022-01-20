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
    /// Represents a grid column builder
    /// </summary>
    public class GridColumnsBuilder<T> : IJToken
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridColumnsBuilder"/>
        /// </summary>
        public GridColumnsBuilder()
        {
            Column = new GridColumnOptions<T>();
        }

        /// <summary>
        /// Gets the internal column
        /// </summary>
        internal GridColumnOptions<T> Column { get; }



        /// <summary>
        /// Cell type to be created for a column.
        /// </summary>
        /// <param name="cellType"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> CellType(CellType cellType)
        {
            Column.CellType = cellType;
            return this;
        }

        /// <summary>
        /// Action call when button clicked inside column
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Click(string function)
        {
            Column.Click = function;
            return this;
        }

        /// <summary>
        /// Class to assign to each cell in the column.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> ClassName(string className)
        {
            Column.ClassName = className;
            return this;
        }

        /// <summary>
        /// Add padding to the text content used when calculating the optimal with for a table.
        /// </summary>
        /// <param name="contentPadding"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> ContentPadding(string contentPadding)
        {
            Column.ContentPadding = contentPadding;
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Data(string data)
        {
            Column.Data = data;
            return this;
        }

        /// <summary>
        /// Set the data source for the column from the rows data object / array.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Data(int data)
        {
            Column.Data = data;
            return this;
        }

        /// <summary>
        /// Set default, static, content for a column.
        /// </summary>
        /// <param name="defaultContent"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> DefaultContent(string defaultContent)
        {
            Column.DefaultContent = defaultContent;
            return this;
        }

        /// <summary>
        /// Set a descriptive name for a column.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Name(string name)
        {
            Column.Name = name;
            return this;
        }

        /// <summary>
        /// Enable or disable ordering on this column. 
        /// </summary>
        /// <param name="orderable"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Orderable(bool orderable)
        {
            Column.Orderable = orderable;
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="column">A single column index to order upon</param>
        /// <returns></returns>
        public GridColumnsBuilder<T> OrderData(int column)
        {
            Column.OrderData = new int[] { column };
            return this;
        }

        /// <summary>
        /// Define multiple column ordering as the default order for a column.
        /// </summary>
        /// <param name="columns">Multiple column indexes to define multi-column sorting</param>
        /// <returns></returns>
        public GridColumnsBuilder<T> OrderData(int[] columns)
        {
            Column.OrderData = columns;
            return this;
        }

        /// <summary>
        /// Live DOM sorting type assignment.
        /// </summary>
        /// <param name="orderDataType"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> OrderDataType(string orderDataType)
        {
            Column.OrderDataType = orderDataType;
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="render"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Render(string render)
        {
            Column.Render = new RenderOptions(RenderType.String, render);
            return this;
        }

        /// <summary>
        /// Render (process) the data for use in the table.
        /// </summary>
        /// <param name="function"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Render(Func<string> function)
        {
            Column.Render = new RenderOptions(RenderType.Function, $"function(d,t,r,m){{return {function()}(d,t,r,m);}}");
            return this;
        }

        /// <summary>
        /// Enable or disable filtering on the data in this column.
        /// </summary>
        /// <param name="searchable"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Searchable(bool searchable)
        {
            Column.Searchable = searchable;
            return this;
        }

        /// <summary>
        /// Set the column title.
        /// </summary>
        /// <param name="title"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Title(string title)
        {
            Column.Title = title;
            return this;
        }


        /// <summary>
        /// Set the column type - used for filtering and sorting string processing.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Type(string type)
        {
            Column.Type = type;
            return this;
        }

        /// <summary>
        /// Enable or disable the display of this column.
        /// </summary>
        /// <param name="visible"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Visible(bool visible)
        {
            Column.Visible = visible;
            return this;
        }

        /// <summary>
        /// Column width assignment.
        /// </summary>
        /// <param name="width"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Width(string width)
        {
            Column.Width = width;
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            //columns.cellType
            //columns.className
            //columns.contentPadding
            //columns.createdCell
            //columns.data
            //columns.defaultContent
            //columns.name
            //columns.orderable
            //columns.orderData
            //columns.orderDataType
            //columns.render
            //columns.searchable
            //columns.title
            //columns.type
            //columns.visible
            //columns.width

            // data and orderData are full formatted
            JObject jObject = new JObject();
            if (Column.CellType != Builders.CellType.td) jObject.Add("cellType", new JValue("tr"));
            if (!string.IsNullOrEmpty(Column.ClassName)) jObject.Add("className", new JValue(Column.ClassName));
            if (!string.IsNullOrEmpty(Column.ContentPadding)) jObject.Add("contentPadding", new JValue(Column.ContentPadding));
            // data is string or int
            if (Column.Data != null) jObject.Add("data", new JValue(Column.Data));
            if (!string.IsNullOrEmpty(Column.DefaultContent)) jObject.Add("defaultContent", new JValue(Column.DefaultContent));
            if (!string.IsNullOrEmpty(Column.Name)) jObject.Add("name", new JValue(Column.Name));
            if (!Column.Orderable) jObject.Add("orderable", new JValue(false));
            // int[]
            if (Column.OrderData != null) jObject.Add("orderData", new JArray(Column.OrderData));
            if (!string.IsNullOrEmpty(Column.OrderDataType)) jObject.Add("orderDataType", new JValue(Column.OrderDataType));
            if (Column.Render != null)
            {
                if (Column.Render.RenderType == RenderType.String)
                {
                    // Template
                    if (Column.Render.Render == null)
                    {
                        jObject.Add("render", new JRaw("null"));
                    }
                    else
                    {
                        jObject.Add("render", new JValue(Column.Render.Render));
                    }
                }
                else if (Column.Render.RenderType == RenderType.Function)
                {
                    // Function
                    jObject.Add("render", new JRaw(Column.Render.Render));
                }
            }
            if (!Column.Searchable) jObject.Add("searchable", new JValue(false));
            if (!string.IsNullOrEmpty(Column.Title)) jObject.Add("title", new JValue(Column.Title));
            if (!string.IsNullOrEmpty(Column.Type)) jObject.Add("type", new JValue(Column.Type));
            if (!Column.Visible) jObject.Add("visible", new JValue(false));
            if (!string.IsNullOrEmpty(Column.Width)) jObject.Add("width", new JValue(Column.Width));

            return jObject;
        }
    }
}
