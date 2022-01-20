using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json.Linq;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents a builder for ajax options
    /// </summary>
    public class ArrayBuilder<T> : IJToken
    {
        ArrayOptions<T> arrayObject;

        /// <summary>
        /// Initialize a new instance of <see cref="ArrayBuilder{T}"/>
        /// </summary>
        public ArrayBuilder()
        {
            arrayObject = new ArrayOptions<T>();
        }

        /// <summary>
        /// Sets tha ajax url
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public ArrayBuilder<T> Data(IEnumerable<T> data)
        {
            arrayObject.Data = data;
            return this;
        }

        /// <summary>
        /// Gets the <see cref="JToken"/> of current instance
        /// </summary>
        /// <returns></returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public JToken ToJToken()
        {
            JRaw jObject = new JRaw(arrayObject.Data.ToJson());
            return jObject;
        }
    }
}