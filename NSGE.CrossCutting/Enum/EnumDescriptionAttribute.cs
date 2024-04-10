namespace NSGE.CrosCutting.Enum
{
    public class EnumDescriptionAttribute : Attribute
    {
        public EnumDescriptionAttribute(string value)
        {
            EnumDescription = value;
        }

        public string EnumDescription { get; protected set; }
        
    }
}