## CreateInstance
Comparison of methods for creating a new instance in .net
[blogs.msdn.microsoft.com](https://blogs.msdn.microsoft.com/seteplia/2017/02/01/dissecting-the-new-constraint-in-c-a-perfect-example-of-a-leaky-abstraction/)

### Results:
``` ini

BenchmarkDotNet=v0.10.1, OS=Microsoft Windows NT 6.2.9200.0
Processor=AMD FX(tm)-8300 Eight-Core Processor , ProcessorCount=8
Frequency=3237665 Hz, Resolution=308.8646 ns, Timer=TSC
  [Host]     : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0 [AttachedDebugger]
  DefaultJob : Clr 4.0.30319.42000, 64bit RyuJIT-v4.6.1586.0


```
                                    Method |       Mean |    StdErr |    StdDev | Scaled | Scaled-StdDev |  Gen 0 | Allocated |
------------------------------------------ |----------- |---------- |---------- |------- |-------------- |------- |---------- |
                                Ñontrustor |  7.3578 ns | 0.1127 ns | 0.4366 ns |   1.00 |          0.00 | 0.0252 |      40 B |
                                   new T() | 98.5826 ns | 1.0797 ns | 4.9480 ns |  13.44 |          1.03 | 0.0223 |      40 B |
                  Activator.CreateInstance | 83.5369 ns | 1.0136 ns | 3.6547 ns |  11.39 |          0.82 | 0.0234 |      40 B |
                Activator.CreateInstanc<T> | 97.1237 ns | 1.1146 ns | 5.3454 ns |  13.24 |          1.05 | 0.0190 |      40 B |
                         FastObjectFactory | 10.9606 ns | 0.1517 ns | 0.6253 ns |   1.49 |          0.12 | 0.0252 |      40 B |
                      ExpressionsActivator | 16.3574 ns | 0.2097 ns | 0.7848 ns |   2.23 |          0.17 | 0.0246 |      40 B |
               DynamicModuleLambdaCompiler |  9.2815 ns | 0.1350 ns | 0.5401 ns |   1.27 |          0.10 | 0.0247 |      40 B |
                   FastActivator<T>.Create |  9.5878 ns | 0.1406 ns | 0.8076 ns |   1.31 |          0.13 | 0.0252 |      40 B |
           FastActivator.CreateInstance<T> | 25.7931 ns | 0.3022 ns | 1.3172 ns |   3.52 |          0.27 | 0.0240 |      40 B |
               ExtensionsNew.NewFactory<T> | 17.0394 ns | 0.2196 ns | 1.1198 ns |   2.32 |          0.20 | 0.0252 |      40 B |
                  ExtensionsNew.NewFactory | 19.6788 ns | 0.2411 ns | 1.4862 ns |   2.68 |          0.25 | 0.0247 |      40 B |
   ExtensionsNew.NewFactory<T> with params | 92.4184 ns | 0.8250 ns | 3.1951 ns |  12.60 |          0.85 | 0.1244 |     200 B |
      ExtensionsNew.NewFactory with params | 97.7812 ns | 1.0220 ns | 3.9581 ns |  13.33 |          0.94 | 0.1209 |     200 B |
