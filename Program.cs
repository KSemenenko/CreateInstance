using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;

namespace CreateInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            int MAX = 10000000;
            Stopwatch watch;

            Console.WriteLine("Number of iterates: {0}", MAX);
            Console.WriteLine();

            watch = Stopwatch.StartNew();
            for (int i = 0; i < MAX; i++)
            {
                MyObject myObj = Activator.CreateInstance(typeof(MyObject)) as MyObject;
            }
            Console.WriteLine("Activator.CreateInstance(Type): {0,30}", watch.Elapsed);


            watch = Stopwatch.StartNew();
            for (int i = 0; i < MAX; i++)
            {
                MyObject myObj = Activator.CreateInstance<MyObject>();

            }
            Console.WriteLine("Activator.CreateInstance<T>(): {0,31}", watch.Elapsed);


            watch = Stopwatch.StartNew();
            FastObjectFactory.CreateObject creator = FastObjectFactory.CreateObjectFactory <MyObject>();
            for (int i = 0; i < MAX; i++)
            {
                MyObject myObj = creator() as MyObject;

            }
            Console.WriteLine("FastObjectFactory.CreateObjec (empty cache): {0,17}", watch.Elapsed);


            watch = Stopwatch.StartNew();
            FastObjectFactory.CreateObject creator2 = FastObjectFactory.CreateObjectFactory<MyObject>();
            for (int i = 0; i < MAX; i++)
            {
                MyObject myObj = creator2() as MyObject;

            }
            Console.WriteLine("FastObjectFactory.CreateObjec (cache full): {0,18}", watch.Elapsed);

            watch = Stopwatch.StartNew();
            ConstructorInfo ctor = typeof(MyObject).GetConstructors().First();
            ExpressionsActivator.ObjectActivator<MyObject> createdActivator = ExpressionsActivator.GetActivator<MyObject>(ctor);

            for (int i = 0; i < MAX; i++)
            {
                MyObject myObj = createdActivator();

            }
            Console.WriteLine("Linq Expressions – Creating objects:        {0,18}", watch.Elapsed);

            watch = Stopwatch.StartNew();
            var factory1 = new ItemFactory<MyObject>();
            for (int i = 0; i < MAX; i++)
            {
                MyObject f = factory1.GetNewItem();
            }
            Console.WriteLine("new T():                                    {0,38}", watch.Elapsed);

            Console.ReadLine();
        }


        private class ItemFactory<T> where T : new()
        {
            public T GetNewItem()
            {
                return new T();
            }
        } 


        public class MyObject
        {
            public string n { get; set; }
            public int n1 { get; set; }
            public string n2 { get; set; }
            public string n3 { get; set; }
            public string n4 { get; set; }
            public string n5 { get; set; }
            public string n6 { get; set; }
            public string n7 { get; set; }
            public string n8 { get; set; }
            public List<string> n9 { get; private set; }
        }
    }
}
