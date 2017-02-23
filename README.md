## CreateInstance
Comparison of methods for creating a new instance in .net
[blogs.msdn.microsoft.com](https://blogs.msdn.microsoft.com/seteplia/2017/02/01/dissecting-the-new-constraint-in-c-a-perfect-example-of-a-leaky-abstraction/)

### Simple Results:
                             Method |        Mean |    StdErr |     StdDev |      Median |  Gen 0 | Allocated |
----------------------------------- |------------ |---------- |----------- |------------ |------- |---------- |
                    ConstructorTest |  15.1381 ns | 0.2054 ns |  1.9267 ns |  15.0851 ns | 0.0251 |      40 B |
                 GenericFactoryTest | 154.0438 ns | 1.5583 ns |  9.7315 ns | 154.3541 ns | 0.0239 |      40 B |
                ActivatorTypeofTest | 113.4249 ns | 1.2142 ns |  9.8643 ns | 112.5045 ns | 0.0244 |      40 B |
               ActivatorGenericTest | 120.1139 ns | 1.2689 ns | 12.6888 ns | 118.5508 ns | 0.0242 |      40 B |
              FastObjectFactoryTest |  37.2223 ns | 0.4620 ns |  4.6199 ns |  36.8112 ns | 0.0222 |      40 B |
           ExpressionsActivatorTest |  54.6673 ns | 1.0728 ns | 10.7284 ns |  50.8222 ns | 0.0226 |      40 B |
                  FastActivatorTest |  65.3772 ns | 0.6950 ns |  5.0116 ns |  64.6117 ns | 0.0242 |      40 B |
    DynamicModuleLambdaCompilerTest |  30.2163 ns | 0.3774 ns |  3.7360 ns |  29.4017 ns | 0.0251 |      40 B |
           FastActivatorGenericTest |  30.6653 ns | 0.3743 ns |  3.7247 ns |  30.3712 ns | 0.0251 |      40 B |
           ExtensionsNewGenericTest |  37.3539 ns | 0.4457 ns |  3.2137 ns |  37.0942 ns | 0.0251 |      40 B |
            ExtensionsNewTypeofTest |  41.0911 ns | 0.4576 ns |  3.3314 ns |  40.9727 ns | 0.0251 |      40 B |
 ExtensionsNewGenericParametersTest | 145.1903 ns | 1.4698 ns |  9.1789 ns | 143.9723 ns | 0.1235 |     200 B |
  ExtensionsNewObjectParametersTest | 144.0337 ns | 1.4730 ns | 10.0987 ns | 141.7513 ns | 0.1198 |     200 B |
