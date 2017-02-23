using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CreateInstance.Methods
{
    public static class FastActivator
    {
        public static T CreateInstance<T>() where T : new()
        {
            return FastActivatorImpl<T>.NewFunction();
        }

        private static class FastActivatorImpl<T> where T : new()
        {
            // Compiler translates 'new T()' into Expression.New()
            private static readonly Expression<Func<T>> NewExpression = () => new T();

            // Compiling expression into the delegate
            public static readonly Func<T> NewFunction = NewExpression.Compile();
        }
    }

    public static class FastActivator<T> where T : new()
    {
        /// <summary>
        /// Extremely fast generic factory method that returns an instance
        /// of the type <typeparam name="T"/>.
        /// </summary>
        public static readonly Func<T> Create = DynamicModuleLambdaCompiler.GenerateFactory<T>();
    }
}