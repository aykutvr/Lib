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
    /// Represents columnDefs target
    /// </summary>
    public class ColumnDefsTargets<T> : IJToken
    {
        private string target;
        private GridColumnsBuilder<T> column;

        /// <summary>
        /// Initialize a new instance of <see cref="ColumnDefsTargets"/>
        /// </summary>
        /// <param name="target"></param>
        /// <param name="column"></param>
        public ColumnDefsTargets(string target, GridColumnsBuilder<T> column)
        {
            this.target = target;
            this.column = column;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JObject jObject = new JObject();
            jObject.Add("targets", new JRaw(target));
            // Merge column
            jObject.Merge(column.ToJToken());
            return jObject;
        }
    }
}
