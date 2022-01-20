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
    /// Represents the language options
    /// </summary>
    public class LanguageBuilder : IJToken
    {
        LanguageOptions lg;

        /// <summary>
        /// Initialize a new instance of <see cref="LanguageBuilder"/>
        /// </summary>
        public LanguageBuilder()
        {
            lg = new LanguageOptions();
        }

        /// <summary>
        /// Load language information from remote file
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public LanguageBuilder Url(string url)
        {
            lg.Url = url;
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
            if (!string.IsNullOrEmpty(lg.Url)) jObject.Add("url", new JValue(lg.Url));
            return jObject;
        }
    }
}
