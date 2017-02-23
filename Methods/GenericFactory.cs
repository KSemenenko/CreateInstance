using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreateInstance.Methods
{
    public class GenericFactory<T> where T : new()
    {
        public T GetNewItem()
        {
            return new T();
        }
    }
}
