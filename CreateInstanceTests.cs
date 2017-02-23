using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Attributes.Exporters;
using CreateInstance.Methods;

namespace CreateInstance
{
    [MarkdownExporter, AsciiDocExporter, HtmlExporter, CsvExporter, RPlotExporter]
    public class CreateInstanceTests
    {
        private readonly FastObjectFactory.CreateObject fastObjectFactory;
        private readonly ExpressionsActivator.ObjectActivator<MyTestObject> expressionsActivator;
        private readonly GenericFactory<MyTestObject> genericFactory;
        private readonly Func<MyTestObject> dynamicModuleFactory;
        private readonly Func<MyTestObject> expressionNewFactory;
        private readonly Func<object> expressionNewObjectFactory;
        private readonly Func<object[], MyTestObject> expressionNewParametersFactory;
        private readonly Func<object[], object> expressionNewParametersObjectFactory;

        public CreateInstanceTests()
        {
            expressionsActivator = ExpressionsActivator.Get<MyTestObject>();
            fastObjectFactory = FastObjectFactory.CreateObjectFactory<MyTestObject>();
            genericFactory = new GenericFactory<MyTestObject>();
            dynamicModuleFactory = DynamicModuleLambdaCompiler.GenerateFactory<MyTestObject>();
            expressionNewFactory = ExtensionsNew.NewFactory<MyTestObject>();
            expressionNewObjectFactory = ExtensionsNew.NewFactory(typeof(MyTestObject));

            expressionNewParametersFactory = ExtensionsNew.NewFactory<MyTestObject>(typeof(string), typeof(int));
            expressionNewParametersObjectFactory = ExtensionsNew.NewFactory(typeof(MyTestObject), typeof(string), typeof(int));
        }

        [Benchmark(Baseline = true, Description = "Сontrustor")]
        public MyTestObject ConstructorTest()
        {
            return new MyTestObject();
        }

        [Benchmark(Description = "new T()")]
        public MyTestObject GenericFactoryTest()
        {
            return genericFactory.GetNewItem();
        }

        [Benchmark(Description = "Activator.CreateInstance")]
        public MyTestObject ActivatorTypeofTest()
        {
            return (MyTestObject)Activator.CreateInstance(typeof(MyTestObject));
        }

        [Benchmark(Description = "Activator.CreateInstanc<T>")]
        public MyTestObject ActivatorGenericTest()
        {
            return Activator.CreateInstance<MyTestObject>();
        }

        [Benchmark(Description = "FastObjectFactory")]
        public MyTestObject FastObjectFactoryTest()
        {
            return (MyTestObject)fastObjectFactory();
        }

        [Benchmark(Description = "ExpressionsActivator")]
        public MyTestObject ExpressionsActivatorTest()
        {
            return expressionsActivator();
        }

        [Benchmark(Description = "DynamicModuleLambdaCompiler")]
        public MyTestObject DynamicModuleLambdaCompilerTest()
        {
            return dynamicModuleFactory();
        }

        [Benchmark(Description = "FastActivator<T>.Create")]
        public MyTestObject FastActivatorGenericTest()
        {
            return FastActivator<MyTestObject>.Create();
        }

        [Benchmark(Description = "FastActivator.CreateInstance<T>")]
        public MyTestObject FastActivatorTest()
        {
            return FastActivator.CreateInstance<MyTestObject>();
        }

        [Benchmark(Description = "ExtensionsNew.NewFactory<T>")]
        public MyTestObject ExtensionsNewGenericTest()
        {
            return expressionNewFactory();
        }

        [Benchmark(Description = "ExtensionsNew.NewFactory")]
        public MyTestObject ExtensionsNewTypeofTest()
        {
            return (MyTestObject)expressionNewObjectFactory();
        }

        [Benchmark(Description = "ExtensionsNew.NewFactory<T> with params")]
        public MyTestObject ExtensionsNewGenericParametersTest()
        {
            return expressionNewParametersFactory(new object[]{"1", 2});
        }

        [Benchmark(Description = "ExtensionsNew.NewFactory with params")]
        public MyTestObject ExtensionsNewObjectParametersTest()
        {
            return (MyTestObject)expressionNewParametersObjectFactory(new object[] { "1", 2 });
        }
    }
}