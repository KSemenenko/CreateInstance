using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BenchmarkDotNet.Attributes;
using CreateInstance.Methods;

namespace CreateInstance
{
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

        [Benchmark]
        public MyTestObject ConstructorTest()
        {
            return new MyTestObject();
        }

        [Benchmark]
        public MyTestObject GenericFactoryTest()
        {
            return genericFactory.GetNewItem();
        }

        [Benchmark]
        public MyTestObject ActivatorTypeofTest()
        {
            return Activator.CreateInstance(typeof(MyTestObject)) as MyTestObject;
        }

        [Benchmark]
        public MyTestObject ActivatorGenericTest()
        {
            return Activator.CreateInstance<MyTestObject>();
        }

        [Benchmark]
        public MyTestObject FastObjectFactoryTest()
        {
            return (MyTestObject)fastObjectFactory();
        }

        [Benchmark]
        public MyTestObject ExpressionsActivatorTest()
        {
            return expressionsActivator();
        }

        [Benchmark]
        public MyTestObject FastActivatorTest()
        {
            return FastActivator.CreateInstance<MyTestObject>();
        }

        [Benchmark]
        public MyTestObject DynamicModuleLambdaCompilerTest()
        {
            return dynamicModuleFactory();
        }

        [Benchmark]
        public MyTestObject FastActivatorGenericTest()
        {
            return FastActivator<MyTestObject>.Create();
        }

        [Benchmark]
        public MyTestObject ExtensionsNewGenericTest()
        {
            return expressionNewFactory();
        }

        [Benchmark]
        public MyTestObject ExtensionsNewTypeofTest()
        {
            return (MyTestObject)expressionNewObjectFactory();
        }

        [Benchmark]
        public MyTestObject ExtensionsNewGenericParametersTest()
        {
            return expressionNewParametersFactory(new object[]{"1", 2});
        }

        [Benchmark]
        public MyTestObject ExtensionsNewObjectParametersTest()
        {
            return (MyTestObject)expressionNewParametersObjectFactory(new object[] { "1", 2 });
        }
    }
}