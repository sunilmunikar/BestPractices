using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Cqrs
{
    public interface IQueryHandler<in TParameter, out TResult>
        where TResult : IQueryResult
        where TParameter : IQuery
    {
        /// <summary>
        /// Retrieve a query result from a query
        /// </summary>
        /// <param name="query">Query</param>
        /// <returns>Retrieve Query Result</returns>
        TResult Retrieve(TParameter query);
    }
}
