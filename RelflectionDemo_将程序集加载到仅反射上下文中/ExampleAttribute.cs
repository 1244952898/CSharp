using System;

namespace RelflectionDemo_将程序集加载到仅反射上下文中
{
    [AttributeUsage(AttributeTargets.All)]
    public class ExampleAttribute : Attribute
    {
        // Data for properties.
        private ExampleKind kindValue;
        private string noteValue;
        private string[] arrayStrings;
        private int[] arrayNumbers;

        // Constructors. The parameterless constructor (.ctor) calls
        // the constructor that specifies ExampleKind and an array of 
        // strings, and supplies the default values.
        //
        public ExampleAttribute(ExampleKind initKind, string[] initStrings)
        {
            kindValue = initKind;
            arrayStrings = initStrings;
        }

        public ExampleAttribute(ExampleKind initKind) : this(initKind, null)
        {

        }

        public ExampleAttribute() : this(ExampleKind.FirstKind, null)
        {

        }

        public string Note
        {
            get
            {
                return noteValue;
            }
            set
            {
                noteValue = value;
            }
        }
        public int[] Numbers
        {
            get
            {
                return arrayNumbers;
            }
            set
            {
                arrayNumbers = value;
            }
        }
    }
}
