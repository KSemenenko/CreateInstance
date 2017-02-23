using System;
using System.Linq;
using System.Linq.Expressions;

namespace CreateInstance.Methods
{
    public static class ExtensionsNew
    {
        public static Func<T> NewFactory<T>()
        {
            Type type = typeof(T);
            Func<T> method = Expression.Lambda<Func<T>>(Expression.Block(type, new Expression[] { Expression.New(type) })).Compile();
            return method;
        }

        public static Func<object> NewFactory(Type type)
        {
            Func<object> method = Expression.Lambda<Func<object>>(Expression.Block(type, new Expression[] { Expression.New(type) })).Compile();
            return method;
        }

        public static Func<object[],object> NewFactory(Type type, params Type[] parameters)
        {
            var constructorInfo = type.GetConstructor(parameters);

            var args = Expression.Parameter(typeof(object[]), "args");
            var body = Expression.New(constructorInfo,
                                      parameters.Select((t, i) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(i)), t)));
            var outer = Expression.Lambda<Func<object[], object>>(body, args);
            var func = outer.Compile();
            return func;
        }

        public static Func<object[], T> NewFactory<T>(params Type[] parameters)
        {
            Type type = typeof(T);
            var constructorInfo = type.GetConstructor(parameters);

            var args = Expression.Parameter(typeof(object[]), "args");
            var body = Expression.New(constructorInfo,
                                      parameters.Select((t, i) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(i)), t)));
            var outer = Expression.Lambda<Func<object[], T>>(body, args);
            var func = outer.Compile();
            return func;
        }
    }
}