using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Provides functionalities for Json 
    /// </summary>
    interface IJToken
    {
        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        JToken ToJToken();
    }
}
