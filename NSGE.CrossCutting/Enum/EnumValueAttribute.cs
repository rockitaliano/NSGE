namespace NSGE.CrosCutting.Enum
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class EnumValueAttribute : Attribute
    {
        public EnumValueAttribute(string value)
        {
            this.EnumValue = value;
        }

        public string EnumValue { get; protected set; }

        //[AttributeUsage(AttributeTargets.Field)]
        //public class EnumValueAttributes : Attribute
        //{
        //    public string Value { get; }

        //    public EnumValueAttribute(string value)
        //    {
        //        Value = value;
        //    }
        //}
    }
}