using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

//http://weblogs.asp.net/bleroy/archive/2014/04/21/on-accessing-chains-of-potentially-null-properties.aspx
namespace My.Framework.Helper
{
    public static class NotNull
    {
        public static TProp Get<TSource, TProp>(this TSource source, Expression<Func<TSource, TProp>> property) where TSource : class
        {
            if (source == null) return default(TProp);

            var current = property.Body;
            var properties = new List<PropertyInfo>();
            while (!(current is ParameterExpression))
            {
                var memberExpression = current as MemberExpression;
                if (memberExpression == null || !(memberExpression.Member is PropertyInfo))
                {
                    throw new InvalidOperationException("All members in the expression must be properties.");
                }
                properties.Add((PropertyInfo)memberExpression.Member);
                current = memberExpression.Expression;
            }
            properties.Reverse();
            object currentValue = source;
            foreach (var propertyInfo in properties)
            {
                if (currentValue == null) return default(TProp);

                currentValue = propertyInfo.GetValue(currentValue);
            }
            return (TProp)currentValue;
        }
    }
}