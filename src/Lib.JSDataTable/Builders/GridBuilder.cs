using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Html;
using System.Text.Encodings.Web;
using System.Linq;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents a dataTable builder
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GridBuilder<T> : IHtmlContent where T : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="GridBuilder{T}"/>
        /// </summary>
        public GridBuilder()
        {
            Grid = new GridOptions<T>();
        }

        #region Properties
        /// <summary>
        /// Gets the undelying <see cref="GridOptions{T}"/>
        /// </summary>
        internal GridOptions<T> Grid { get; }
        /// <summary>
        /// Gets or sets the <see cref="OrderBuilder"/>
        /// </summary>
        private OrderBuilder OrderBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ColumnDefsFactory"/>
        /// </summary>
        private ColumnDefsFactory<T> ColumnDefsFactory { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="GridDataSourceBuilder"/>
        /// </summary>
        private GridDataSourceBuilder GridDataSourceBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="GridDataSourceBuilder"/>
        /// </summary>
        private GridDataSourceBuilder<T> GridTDataSourceBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="ColumnsFactory"/>
        /// </summary>
        private ColumnsFactory<T> ColumnsFactory { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="GridButtonsFactory"/>
        /// </summary>
        private GridButtonsFactory<T> GridButtonsFactory { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="SelectBuilder"/>
        /// </summary>
        private SelectBuilder SelectBuilder { get; set; }
        /// <summary>
        /// Gets or sets the events builder
        /// </summary>
        private EventsBuilder EventsBuilder { get; set; }
        /// <summary>
        /// Gets or sets the language builder
        /// </summary>
        private LanguageBuilder LanguageBuilder { get; set; }
        /// <summary>
        /// Gets or sets the <see cref="LengthMenuBuilder"/>
        /// </summary>
        private LengthMenuBuilder LengthMenuBuilder { get; set; }
        #endregion

        /// <summary>
        /// Grid name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public GridBuilder<T> Name(string name)
        {
            Grid.Name = name;
            return this;
        }

        /// <summary>
        /// Grid class style
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridBuilder<T> ClassName(string className)
        {
            Grid.ClassName = className;
            return this;
        }

        /// <summary>
        /// Define the table control elements to appear on the page and in what order.
        /// </summary>
        /// <param name="dom"></param>
        /// <returns></returns>
        public GridBuilder<T> Dom(string dom)
        {
            Grid.Dom = dom;
            return this;
        }

        /// <summary>
        /// Feature control DataTables' smart column width handling.
        /// </summary>
        /// <param name="autoWidth"></param>
        /// <returns></returns>
        public GridBuilder<T> AutoWidth(bool autoWidth)
        {
            Grid.AutoWidth = autoWidth;
            return this;
        }

        /// <summary>
        /// Feature control deferred rendering for additional speed of initialisation.
        /// </summary>
        /// <param name="deferRender"></param>
        /// <returns></returns>
        public GridBuilder<T> DeferRender(bool deferRender)
        {
            Grid.DeferRender = deferRender;
            return this;
        }

        /// <summary>
        /// Initial order (sort) to apply to the table.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Order(Action<OrderBuilder> config)
        {
            OrderBuilder = new OrderBuilder();
            config.Invoke(OrderBuilder);

            return this;
        }

        /// <summary>
        /// State saving - restore table state on page reload.
        /// </summary>
        /// <param name="stateSave"></param>
        /// <returns></returns>
        public GridBuilder<T> StateSave(bool stateSave)
        {
            Grid.StateSave = stateSave;
            return this;
        }

        /// <summary>
        /// Feature control search (filtering) abilities.
        /// </summary>
        /// <param name="searching"></param>
        /// <returns></returns>
        public GridBuilder<T> Searching(bool searching)
        {
            Grid.Searching = searching;
            return this;
        }

        /// <summary>
        /// Enable or disable table pagination.
        /// </summary>
        /// <param name="paging"></param>
        /// <returns></returns>
        public GridBuilder<T> Paging(bool paging)
        {
            Grid.Paging = paging;
            return this;
        }

        /// <summary>
        /// Pagination button display options.
        /// </summary>
        /// <param name="pagingType"></param>
        /// <returns></returns>
        public GridBuilder<T> PagingType(PagingType pagingType)
        {
            Grid.PagingType = pagingType;
            return this;
        }

        /// <summary>
        /// Change the options in the page length select list.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> LengthMenu(Action<LengthMenuBuilder> config)
        {
            LengthMenuBuilder = new LengthMenuBuilder();
            config.Invoke(LengthMenuBuilder);

            return this;
        }

        /// <summary>
        /// Feature control ordering (sorting) abilities in DataTables.
        /// </summary>
        /// <param name="ordering"></param>
        /// <returns></returns>
        public GridBuilder<T> Ordering(bool ordering)
        {
            Grid.Ordering = ordering;
            return this;
        }

        /// <summary>
        /// Feature control table information display field.
        /// </summary>
        /// <param name="info"></param>
        /// <returns></returns>
        public GridBuilder<T> Info(bool info)
        {
            Grid.Info = info;
            return this;
        }

        /// <summary>
        /// Multiple column ordering ability control.
        /// </summary>
        /// <param name="orderMulti"></param>
        /// <returns></returns>
        public GridBuilder<T> OrderMulti(bool orderMulti)
        {
            Grid.OrderMulti = orderMulti;
            return this;
        }

        /// <summary>
        /// Data property name that DataTables will use to set tr element DOM IDs.
        /// </summary>
        /// <param name="rowId"></param>
        /// <returns></returns>
        public GridBuilder<T> RowId(string rowId)
        {
            Grid.RowId = rowId;
            return this;
        }

        /// <summary>
        /// Allow the table to reduce in height when a limited number of rows are shown.
        /// </summary>
        /// <param name="scrollCollapse"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollCollapse(bool scrollCollapse)
        {
            Grid.ScrollCollapse = scrollCollapse;
            return this;
        }

        /// <summary>
        /// Horizontal scrolling.
        /// </summary>
        /// <param name="scrollX"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollX(bool scrollX)
        {
            Grid.ScrollX = scrollX;
            return this;
        }

        /// <summary>
        /// Vertical scrolling.
        /// </summary>
        /// <param name="scrollY"></param>
        /// <returns></returns>
        public GridBuilder<T> ScrollY(string scrollY)
        {
            Grid.ScrollY = scrollY;
            return this;
        }

        /// <summary>
        /// Feature control the processing indicator.
        /// </summary>
        /// <param name="processing"></param>
        /// <returns></returns>
        public GridBuilder<T> Processing(bool processing)
        {
            Grid.Processing = processing;
            return this;
        }

        /// <summary>
        /// Feature control DataTables' server-side processing mode.
        /// </summary>
        /// <param name="serverSide"></param>
        /// <returns></returns>
        public GridBuilder<T> ServerSide(bool serverSide)
        {
            Grid.ServerSide = serverSide;
            return this;
        }

        /// <summary>
        /// Set columns.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Columns(Action<ColumnsFactory<T>> config)
        {
            ColumnsFactory = new ColumnsFactory<T>();
            config.Invoke(ColumnsFactory);

            return this;
        }

        /// <summary>
        /// Buttons configuration object.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Buttons(string name, Action<GridButtonsFactory<T>> config)
        {
            GridButtonsFactory = new GridButtonsFactory<T>(name);
            config.Invoke(GridButtonsFactory);

            return this;
        }

        /// <summary>
        /// Set the selection style for end user interaction with the table
        /// </summary>
        /// <param name="select"></param>
        /// <returns></returns>
        public GridBuilder<T> Select(Action<SelectBuilder> select)
        {
            SelectBuilder = new SelectBuilder();
            select.Invoke(SelectBuilder);
            return this;
        }

        /// <summary>
        /// Buttons configuration object.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> Buttons(Action<GridButtonsFactory<T>> config)
        {
            GridButtonsFactory = new GridButtonsFactory<T>();
            config.Invoke(GridButtonsFactory);

            return this;
        }

        /// <summary>
        /// Set column definition initialisation properties.
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> ColumnDefs(Action<ColumnDefsFactory<T>> config)
        {
            ColumnDefsFactory = new ColumnDefsFactory<T>();
            config.Invoke(ColumnDefsFactory);

            return this;
        }

        /// <summary>
        /// Sets the events of dataTable
        /// </summary>
        /// <param name="events"></param>
        /// <returns></returns>
        public GridBuilder<T> Events(Action<EventsBuilder> events)
        {
            EventsBuilder = new EventsBuilder();
            events.Invoke(EventsBuilder);
            return this;
        }

        /// <summary>
        /// DataSources
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> DataSource(Action<GridDataSourceBuilder> config)
        {
            GridDataSourceBuilder = new GridDataSourceBuilder();
            config.Invoke(GridDataSourceBuilder);

            return this;
        }

        /// <summary>
        /// DataSources
        /// </summary>
        /// <param name="config"></param>
        /// <returns></returns>
        public GridBuilder<T> DataSource(Action<GridDataSourceBuilder<T>> config)
        {
            GridTDataSourceBuilder = new GridDataSourceBuilder<T>();
            config.Invoke(GridTDataSourceBuilder);

            return this;
        }

        /// <summary>
        /// Languages options
        /// </summary>
        /// <param name="languages"></param>
        /// <returns></returns>
        public GridBuilder<T> Languages(Action<LanguageBuilder> languages)
        {
            LanguageBuilder = new LanguageBuilder();
            languages.Invoke(LanguageBuilder);

            return this;
        }

        /// <summary>
        /// Writes the content by encoding it with the specified encoder to the specified writer
        /// </summary>
        /// <param name="writer">The <see cref="TextWriter"/> to which the content is written.</param>
        /// <param name="encoder">The System.Text.Encodings.Web.HtmlEncoder which encodes the content to be written.</param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public void WriteTo(TextWriter writer, HtmlEncoder encoder)
        {
            if (string.IsNullOrEmpty(Grid.Name)) throw new ArgumentException("Name property required on grid.");
            bool withClick = ColumnsFactory != null && ColumnsFactory.Columns.Any(c => !string.IsNullOrEmpty(c.Column.Click));

            // Check if element Grid.Name exists
            //< script type = "text/javascript" >
            //    if ($("#example").length == 0) {
            //        document.write('<table id="example" class="display" cellspacing="0" width="100%"></table>')
            //      }
            //</ script >
            writer.Write($"<script type=\"text/javascript\">document.addEventListener(\"DOMContentLoaded\", function(event) {{ if ($(\"#{Grid.Name}\").length==0){{document.write('<table id=\"{Grid.Name}\" class=\"display{(!string.IsNullOrWhiteSpace(Grid.ClassName) ? $" {Grid.ClassName}" : "")}\" cellspacing=\"0\" width=\"100%\"></table>')}}}});</script>");

            // Datables.Net
            writer.Write("<script>$(function(){");
            writer.Write($"var g=$('#{Grid.Name}');var dt=g.DataTable(");


            if (ColumnsFactory == null)
            {
                ColumnsFactory = new ColumnsFactory<T>();
                foreach (var item in typeof(T).GetProperties())
                {
                    ColumnsFactory
                        .Columns
                        .Add(new GridColumnsBuilder<T>()
                                    .CellType(CellType.td)
                                    .Data(item.Name)
                                    .Title(item.GetDisplayName()));
                }
            }

            JObject jObject = new JObject();
            if (!string.IsNullOrEmpty(Grid.RowId)) jObject.Add("rowId", new JValue(Grid.RowId));
            if (!string.IsNullOrEmpty(Grid.Dom)) jObject.Add("dom", new JValue(Grid.Dom));
            if (!Grid.AutoWidth) jObject.Add("autoWidth", new JValue(false));
            if (!Grid.Searching) jObject.Add("searching", new JValue(false));
            if (Grid.StateSave) jObject.Add("stateSave", new JValue(true));
            if (!Grid.Paging) jObject.Add("paging", new JValue(false));
            if (Grid.PagingType != Builders.PagingType.Simple_numbers) jObject.Add($"pagingType", new JValue(Grid.PagingType.ToString().ToLower()));
            if (LengthMenuBuilder != null) jObject.Add("lengthMenu", LengthMenuBuilder.ToJToken());
            if (!Grid.Ordering) jObject.Add("ordering", new JValue(false));
            if (!Grid.Info) jObject.Add("info", new JValue(false));
            if (!Grid.OrderMulti) jObject.Add("orderMulti", new JValue(false));
            if (Grid.ScrollCollapse) jObject.Add("scrollCollapse", new JValue(true));
            if (Grid.ScrollX) jObject.Add("scrollX", new JValue(true));
            if (!string.IsNullOrEmpty(Grid.ScrollY)) jObject.Add($"scrollY", new JValue(Grid.ScrollY));
            if (Grid.Processing) jObject.Add("processing", new JValue(true));
            if (Grid.ServerSide) jObject.Add("serverSide", new JValue(true));
            if (Grid.DeferRender) jObject.Add("deferRender", new JValue(true));
            if (GridDataSourceBuilder != null) jObject.Add("ajax", GridDataSourceBuilder.ToJToken());
            if (SelectBuilder != null) jObject.Add("select", SelectBuilder.ToJToken());
            if (OrderBuilder != null) jObject.Add("order", OrderBuilder.ToJToken());
            if (LanguageBuilder != null) jObject.Add("language", LanguageBuilder.ToJToken());
            if (GridButtonsFactory != null) jObject.Add("buttons", GridButtonsFactory.ToJToken());
            if (ColumnDefsFactory != null) jObject.Add("columnDefs", ColumnDefsFactory.ToJToken());
            if (ColumnsFactory != null) jObject.Add("columns", ColumnsFactory.ToJToken());
            if (GridTDataSourceBuilder != null) jObject.Add("data", GridTDataSourceBuilder.ToJToken());
            writer.Write(jObject.ToString(Newtonsoft.Json.Formatting.None));
            writer.Write(");");

            if (EventsBuilder != null) EventsBuilder.WriteTo(writer, encoder);
            if (withClick)
            {
                writer.Write("var fn=[" + string.Join(",", ColumnsFactory.Columns.Select(e => e.Column.Click)) + "];");
                writer.Write("g.on('click','button',function(){var row=dt.row($(this).parents('tr'));var i=dt.column($(this).parents('td')).index();if (fn.length>i){fn[i]({data:$(this).data(),rowid:row.id(),row:row.data()});}});");
                writer.Write("});</script>");
            }
            else
            {
                writer.Write("});</script>");
            }
        }
    }
}
