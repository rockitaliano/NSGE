using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using NSGE.CrosCutting.Session;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;

namespace NSGE.Services.Session
{
    public class SessionService
    {
        private const string SessionArquivos = "Arquivos";
        private const string SessionEnderecos = "Endereco";
        private const string SessionOrdemServicoVersoes = "OrdemServicoVersoes";
        private const string SessionItemSublocacaoVersao = "ItemSublocacaoVersao";

        

        private static IHttpContextAccessor _httpContextAccessor;
        public static void Configure(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));             
        }
        public static Usuario UsuarioLogado
        {
            get
            {
                return MySession<Usuario>.Current.SessionData;
            }
            set
            {
                MySession<Usuario>.Current.SessionData = value;
            }
        }
        public static List<Permissao> Permissoes
        {
            get
            {
                if (MySession<List<Permissao>>.Current.SessionData == null)
                    Permissoes = new List<Permissao>();

                return MySession<List<Permissao>>.Current.SessionData;
            }
            set
            {
                MySession<List<Permissao>>.Current.SessionData = value;
            }
        }


        public static List<Endereco> Enderecos
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    var json = httpContext.Session.GetString(SessionEnderecos);

                    if (json != null)
                        return JsonConvert.DeserializeObject<List<Endereco>>(json);
                }

                return new List<Endereco>();
            }
            set
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    var json = JsonConvert.SerializeObject(value);
                    httpContext.Session.SetString(SessionEnderecos, json);
                }
            }
        }

        public static List<Arquivo>? Arquivos
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    var json = httpContext.Session.GetString(SessionArquivos);

                    if (json != null)
                        return JsonConvert.DeserializeObject<List<Arquivo>>(json);
                }

                return new List<Arquivo>();
            }
            set
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    var json = JsonConvert.SerializeObject(value);
                    httpContext.Session.SetString(SessionArquivos, json);
                }
            }
        }

        public static List<ItemOrdemServicoVersao>? OrdemServicoVersoes
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    var json = httpContext.Session.GetString(SessionOrdemServicoVersoes);

                    if (json != null)
                        return JsonConvert.DeserializeObject<List<ItemOrdemServicoVersao>>(json);
                }

                return new List<ItemOrdemServicoVersao>();
            }
            set
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    var json = JsonConvert.SerializeObject(value);
                    httpContext.Session.SetString(SessionOrdemServicoVersoes, json);
                }
            }
        }

        public static List<ItemSublocacaoOrdemServicoVersao> ItemSublocacaoVersao
        {
            get
            {
                var httpContext = _httpContextAccessor.HttpContext;
                if (httpContext != null)
                {
                    var json = httpContext.Session.GetString(SessionItemSublocacaoVersao);

                    if (json != null)
                        return JsonConvert.DeserializeObject<List<ItemSublocacaoOrdemServicoVersao>>(json);
                }

                return new List<ItemSublocacaoOrdemServicoVersao>();
            }
            set
            {
                var httpContext = _httpContextAccessor.HttpContext;

                if (httpContext != null)
                {
                    var json = JsonConvert.SerializeObject(value);
                    httpContext.Session.SetString(SessionItemSublocacaoVersao, json);
                }
            }
        }
    }
}