namespace NSGE.CrossCutting.CustomException
{
    public class NSGECustomException : System.Exception
    {
        public string PropertyModelError { get; set; }

        public bool HasModelError
        {
            get
            {
                return !string.IsNullOrEmpty(PropertyModelError);
            }
        }

        public NSGECustomException(string msg, string propertyModel = "")
            : base(msg)
        {
            this.PropertyModelError = propertyModel;
        }
    }
}