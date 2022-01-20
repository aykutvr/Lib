using System.Collections.Generic;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents an ajax object
    /// </summary>
    class ArrayOptions<T>
    {
        /// <summary>
        /// Gets or sets ajax url
        /// </summary>
        public IEnumerable<T> Data { get; set; }

    }
}
