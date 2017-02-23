using System;
using BenchmarkDotNet.Running;

namespace CreateInstance
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            //CreateInstanceTests tests = new CreateInstanceTests();
            //var x1 = tests.ExtensionsNewGenericParametersTest();
            //var x2 = tests.ExtensionsNewObjectParametersTest();

            var summary = BenchmarkRunner.Run<CreateInstanceTests>();
            Console.ReadLine();
        }
    }
}