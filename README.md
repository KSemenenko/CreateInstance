## CreateInstance
Comparison of methods for creating a new instance in .net

### Simple Results:
Func name|Time
:--|:-:
Activator.CreateInstance(Type):| 00:00:14:6118054
Activator.CreateInstance<T>():|00:00:04:7137484
FastObjectFactory.CreateObjec (empty cache):|00:00:00:1589818
FastObjectFactory.CreateObjec (cache full):|00:00:00:1580787
Linq Expressions – Creating objects:|00:00:00:1750399
new T() :|00:00:05:2691291
Expressions New :|00:00:00:0029807
Expressions New<T>  :|00:00:00:0024208
Expressions New<T>(prm) :|00:00:00:0039466