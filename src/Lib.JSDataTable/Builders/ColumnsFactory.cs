﻿using Microsoft.AspNetCore.Html;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq.Expressions;
using System.Text;
using System.Text.Encodings.Web;

namespace Lib.DataTablesNet.Builders
{
    /// <summary>
    /// Represents a factory of <see cref="GridColumnsBuilder"/>
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public class ColumnsFactory<TModel> : IJToken where TModel : class
    {
        /// <summary>
        /// Initialize a new instance of <see cref="ColumnsFactory{TModel}"/>
        /// </summary>
        public ColumnsFactory()
        {
            Columns = new List<GridColumnsBuilder<TModel>>();
        }

        /// <summary>
        /// Gets the list of columns
        /// </summary>
        internal IList<GridColumnsBuilder<TModel>> Columns { get; }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public GridColumnsBuilder<TModel> Add<T>()
        {
            GridColumnsBuilder<TModel> column = new GridColumnsBuilder<TModel>();
            Columns.Add(column);
            return column;
        }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="propertyName"></param>
        /// <returns></returns>
        public GridColumnsBuilder<TModel> Add<T>(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)) throw new ArgumentNullException(nameof(propertyName));
            GridColumnsBuilder<TModel> column = new GridColumnsBuilder<TModel>();
            Columns.Add(column.Data(propertyName));
            return column;
        }

        /// <summary>
        /// Add a column to the factory
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public GridColumnsBuilder<TModel> Add<T>(Expression<Func<TModel, T>> expression)
        {
            var p = PropertyBuilder.GetPropertyInfo(expression);
            string pName = PropertyBuilder.GetPropertyName(p);

            GridColumnsBuilder<TModel> column = new GridColumnsBuilder<TModel>();
            Columns.Add(column.Data(pName));
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
            for (int i = 0; i < Columns.Count; i++)
            {
                jArray.Add(Columns[i].ToJToken());
            }
            return jArray;
        }
    }
}
