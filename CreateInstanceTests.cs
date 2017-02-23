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
        private readonly ItemFactory<MyTestObject> itemFactory;


        public CreateInstanceTests()
        {
            expressionsActivator = ExpressionsActivator.Get<MyTestObject>();
            fastObjectFactory = FastObjectFactory.CreateObjectFactory<MyTestObject>();
            itemFactory = new ItemFactory<MyTestObject>();
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
        public MyTestObject ItemFactoryTest()
        {
            return itemFactory.GetNewItem();
        }

        [Benchmark]
        public MyTestObject ExtensionsNewTypeofTest()
        {
            return (MyTestObject)ExtensionsNew.New(typeof(MyTestObject));
        }

        [Benchmark]
        public MyTestObject ExtensionsNewTTest()
        {
            return ExtensionsNew.New<MyTestObject>();
        }
        [Benchmark]
        public MyTestObject ExtensionsNewTParamTest()
        {
            return ExtensionsNew.New<MyTestObject>("1",2);
        }
    }
}
