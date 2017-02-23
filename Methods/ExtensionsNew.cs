using System;
using System.Linq;
using System.Linq.Expressions;

namespace CreateInstance.Methods
{
    public static class ExtensionsNew
    {
        public static T New<T>()
        {
            Type type = typeof(T);
            Func<T> method = Expression.Lambda<Func<T>>(Expression.Block(type, new Expression[] { Expression.New(type) })).Compile();
            return method();
        }

        public static object New(Type type)
        {
            Func<object> method = Expression.Lambda<Func<object>>(Expression.Block(type, new Expression[] { Expression.New(type) })).Compile();
            return method();
        }

        public static object New(Type type, params object[] parameters)
        {
            var types = parameters.Select(item => item.GetType()).ToArray();

            var constructorInfo = type.GetConstructor(types);

            var args = Expression.Parameter(typeof(object[]), "args");
            var body = Expression.New(constructorInfo,
                                      types.Select((t, i) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(i)), t)).ToArray());
            var outer = Expression.Lambda<Func<object[], object>>(body, args);
            var func = outer.Compile();
            return func(parameters);
        }

        public static T New<T>(params object[] parameters)
        {
            Type type = typeof(T);
            var types = parameters.Select(item => item.GetType()).ToArray();

            var constructorInfo = type.GetConstructor(types);

            var args = Expression.Parameter(typeof(object[]), "args");
            var body = Expression.New(constructorInfo,
                                      types.Select(
                                          (t, i) => Expression.Convert(Expression.ArrayIndex(args, Expression.Constant(i)), t))
                                           .ToArray());
            var outer = Expression.Lambda<Func<object[], T>>(body, args);
            var func = outer.Compile();

            var obj = func(parameters);
            return obj;
        }
    }
}