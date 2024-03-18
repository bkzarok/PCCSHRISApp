using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
namespace HRISApplication.Utilities
{
  
    public static class QueryableExtensions
    {
        public static IQueryable<T> OrderByColumn<T>(this IQueryable<T> queryable, string columnName)
        {
            // Get the property info for the specified column name
            PropertyInfo propertyInfo = typeof(T).GetProperty(columnName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance);
            if (propertyInfo == null)
            {
                throw new ArgumentException($"Column '{columnName}' not found in type '{typeof(T).Name}'.");
            }

            // Create an expression that accesses the property
            ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
            MemberExpression propertyAccess = Expression.Property(parameter, propertyInfo);
            LambdaExpression orderByExpression = Expression.Lambda(propertyAccess, parameter);

            // Compile the expression and apply OrderBy
            return queryable.OrderBy( o => (dynamic)orderByExpression.Compile());
        }
    }



}
