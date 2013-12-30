using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using My.Framework.Extension;

namespace My.Framework.Filtering
{
    /// <summary>
    /// Allow you to filter your query results by applying a list of strongly typed
    /// lambda expressions tree.
    /// and <see cref="PagingOptions" />.
    /// </summary>
    /// <typeparam name="TSource">The type of the enumerated objects on which filter 
    /// must be applied.</typeparam>
    public class QueryOptions<TSource>
    {
        #region Properties
        /// <summary>
        /// Gets the filter properties as list of strongly typed
        /// lambda expressions tree.
        /// </summary>
        /// <value>
        /// The filter properties.
        /// </value>
        public List<Expression<Func<TSource, bool>>> QueryExpressions { get; private set; }
        #endregion

        #region Constructor(s)
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryOptions{TSource}" /> class
        /// by specifiing an array of strongly typed lambda expressions tree.
        /// </summary>
        /// <param name="filterProperties">The filter properties.<br/>
        /// This value can be null</param>
        public QueryOptions(params Expression<Func<TSource, bool>>[] filterProperties)
        {
            this.QueryExpressions = new List<Expression<Func<TSource, bool>>>();

            //-- Add the filter to the list
            if (filterProperties != null)
            {
                this.QueryExpressions.AddRange(filterProperties);
            }
        }
        #endregion

        #region ILoggable Members
        public string ToLogString()
        {
            var sb = new StringBuilder("QueryOptions")
                .Append(" : ")
                .AppendFormatLine("#Expression(s):'{0}'", this.QueryExpressions.Count);
            foreach (var queryExpression in this.QueryExpressions)
            {
                sb.AppendFormatLine("{0}", queryExpression);
            }
            return sb.ToString();
        }
        #endregion
    }
}
