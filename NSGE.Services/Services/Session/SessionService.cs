using Microsoft.AspNetCore.Http;
using NSGE.CrosCutting.Session;
using NSGE.Domain.Entity.Operacional;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;

namespace NSGE.Services.Services.Session
{
    public class SessionService
    {
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
                    SessionService.Permissoes = new List<Permissao>();

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
                if (MySession<List<Endereco>>.Current.SessionData == null)
                    SessionService.Enderecos = new List<Endereco>();

                return MySession<List<Endereco>>.Current.SessionData;
            }
            set
            {
                MySession<List<Endereco>>.Current.SessionData = value;
            }
        }

        public static List<Arquivo> Arquivos
        {
            get
            {
                if (MySession<List<Arquivo>>.Current.SessionData == null)
                    SessionService.Arquivos = new List<Arquivo>();

                return MySession<List<Arquivo>>.Current.SessionData;
            }
            set
            {
                MySession<List<Arquivo>>.Current.SessionData = value;
            }
        }

        public static List<ItemOrdemServicoVersao> OrdemServicoVersoes
        {
            get
            {
                var session = MySession<List<ItemOrdemServicoVersao>>.Current;
                if (session?.SessionData == null)
                {
                    session = new MySession<List<ItemOrdemServicoVersao>>(new HttpContextAccessor());
                    MySession<List<ItemOrdemServicoVersao>>.Current = session;
                }

                return session.SessionData;
            }
            set
            {
                var session = MySession<List<ItemOrdemServicoVersao>>.Current;
                if (session != null)
                {
                    session.SessionData = value;
                    MySession<List<ItemOrdemServicoVersao>>.Current = session;
                }
            }
        }

        public static List<ItemSublocacaoOrdemServicoVersao> ItemSublocacaoVersao
        {
            get
            {
                var session = MySession<List<ItemSublocacaoOrdemServicoVersao>>.Current;
                if (session?.SessionData == null)
                {
                    session = new MySession<List<ItemSublocacaoOrdemServicoVersao>>(new HttpContextAccessor());
                    MySession<List<ItemSublocacaoOrdemServicoVersao>>.Current = session;
                }

                return session.SessionData;
            }
            set
            {
                var session = MySession<List<ItemSublocacaoOrdemServicoVersao>>.Current;
                if (session != null)
                {
                    session.SessionData = value;
                    MySession<List<ItemSublocacaoOrdemServicoVersao>>.Current = session;
                }
            }
        }
    }
}