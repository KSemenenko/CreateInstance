using System.Collections.Generic;

namespace CreateInstance
{
    public class MyTestObject
    {
        public MyTestObject()
        {
        }

        public MyTestObject(string stringProperty, int intPropery)
        {
            StringProperty = stringProperty;
            IntProperty = intPropery;
            ListStringProperty = new List<string>();
            ListStringProperty.Add(stringProperty);
        }

        public string StringProperty { get; set; }
        public int IntProperty { get; set; }
        public List<string> ListStringProperty { get; }
    }
}