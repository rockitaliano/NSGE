using Microsoft.AspNetCore.Http;
using System.Text;
using System.Text.Json;

namespace NSGE.CrosCutting.Session
{
    public class MySession<T> where T : new()
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MySession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;            
            SessionData = new T();
        }
        private ISession? _session => _httpContextAccessor.HttpContext?.Session;
        public static MySession<T>? Current { get; set; }

        public T SessionData
        {
            get
            {
                var sessionData = _session.GetString("MySessionData");
                return sessionData != null ? JsonSerializer.Deserialize<T>(sessionData) : new T();
            }
            set
            {
                _session?.SetString("MySessionData", JsonSerializer.Serialize(value));
            }
        }
        

        public void Abandon()
        {
            _session.Clear();
        }
    }
}
