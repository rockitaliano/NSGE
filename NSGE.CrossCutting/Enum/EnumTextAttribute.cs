namespace NSGE.CrosCutting.Enum
{
    public class EnumTextAttribute : Attribute
    {
        public string EnumText { get; }
        public EnumTextAttribute(string value)
        {
            EnumText = value;
        }

        public EnumTextAttribute(string messageResourceName, Type messageResourceType)
        {
            this.EnumText = messageResourceName;
            typeof(MessageProcessingHandler).MakeGenericType(messageResourceType);
        }

        //public EnumTextAttribute(string messageResourceName, Type messageResourceType) => this.EnumText = messageResourceName;

        
    }
}