﻿using System;
using System.Collections;
using System.Reflection.Emit;

namespace CreateInstance.Methods
{
    public static class FastObjectFactory
    {
        public delegate object CreateObject();

        private static readonly Hashtable creatorCache = Hashtable.Synchronized(new Hashtable());
        private static readonly Type coType = typeof(CreateObject);

        /// <summary>
        ///     Create a new instance of the specified type
        /// </summary>
        /// <returns></returns>
        public static CreateObject CreateObjectFactory<T>() where T : class
        {
            Type t = typeof(T);
            var c = (CreateObject)creatorCache[t];
            if (c == null)
            {
                lock (creatorCache.SyncRoot)
                {
                    c = creatorCache[t] as CreateObject;
                    if (c != null)
                    {
                        return c;
                    }
                    var dynMethod = new DynamicMethod("DM$OBJ_FACTORY_" + t.Name, typeof(object), null, t);
                    ILGenerator ilGen = dynMethod.GetILGenerator();

                    ilGen.Emit(OpCodes.Newobj, t.GetConstructor(Type.EmptyTypes));
                    ilGen.Emit(OpCodes.Ret);
                    c = (CreateObject)dynMethod.CreateDelegate(coType);
                    creatorCache.Add(t, c);
                }
            }
            return c;
        }
    }
}