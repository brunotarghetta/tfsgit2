using System;
using System.Linq.Expressions;

namespace BCR.Crosscutting.Exceptions
{
    public static class Argument
    {
        public static void ThrowIfNull<T>(Expression<Func<T>> expression)
        {
            MemberExpression body;
            T value;
            Evaluate(expression, out body, out value);

            ThrowIfNull(value, body.Member.Name);
        }

        private static void Evaluate<T>(Expression<Func<T>> expression, out MemberExpression body, out T value)
        {
            body = expression.Body as MemberExpression;
            ThrowIfNull(body, nameof(body));

            var compiled = expression.Compile();

            value = compiled();
        }

        private static void ThrowIfNull<T>(T obj, String parameterName)
        {
            if (obj == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
