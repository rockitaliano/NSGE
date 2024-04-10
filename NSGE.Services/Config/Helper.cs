using NSGE.CrosCutting.Enum;

namespace NSGE.Services.Config
{
    public class Helper
    {
        private static SistemaService _service;
        public Helper(SistemaService service)
        {
            _service = service;
        }

        public static string GetValue(Key key)
        {
            return _service.GetValue(key);
        }
    }
}