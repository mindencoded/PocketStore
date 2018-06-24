using System;
using System.Linq.Expressions;

namespace SchoolExpress.WebService.Helpers
{
    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> GetByIdPredicate<T>(int id)
        {
            ParameterExpression parameter = Expression.Parameter(typeof(T), "item");
            MemberExpression property = Expression.Property(parameter, "Id");
            ConstantExpression constant = Expression.Constant(id);
            BinaryExpression binaryExpression = Expression.MakeBinary(ExpressionType.Equal, property, constant);
            Expression expression = Expression.Lambda(binaryExpression, parameter);
            return expression as Expression<Func<T, bool>>;
        }
    }
}