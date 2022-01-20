using System.IO;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents a columnDefs factory
    /// </summary>
    public class ColumnDefsFactory<T> : IJToken
    {
        IList<ColumnDefsTargets<T>> targets;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnDefsFactory"/>
        /// </summary>
        public ColumnDefsFactory()
        {
            targets = new List<ColumnDefsTargets<T>>();
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Targets(string className)
        {
            GridColumnsBuilder<T> column = new GridColumnsBuilder<T>();
            targets.Add(new ColumnDefsTargets<T>($"\"{className}\"", column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Targets(int columnIndex)
        {
            GridColumnsBuilder<T> column = new GridColumnsBuilder<T>();
            targets.Add(new ColumnDefsTargets<T>(columnIndex.ToString(), column));
            return column;
        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <param name="columnsIndex"></param>
        /// <returns></returns>
        public GridColumnsBuilder<T> Targets(int[] columnsIndex)
        {
            GridColumnsBuilder<T> column = new GridColumnsBuilder<T>();
            targets.Add(new ColumnDefsTargets<T>($"[{string.Join(",", columnsIndex)}]", column));
            return column;

        }

        /// <summary>
        /// Assign a column definition to one or more columns.
        /// </summary>
        /// <returns></returns>
        public GridColumnsBuilder<T> TargetAll()
        {
            GridColumnsBuilder<T> column = new GridColumnsBuilder<T>();
            targets.Add(new ColumnDefsTargets<T>("\"_all\"", column));
            return column;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JArray jArray = new JArray();
            for (int i = 0; i < targets.Count; i++)
            {
                jArray.Add(targets[i].ToJToken());
            }
            return jArray;
        }
    }
}