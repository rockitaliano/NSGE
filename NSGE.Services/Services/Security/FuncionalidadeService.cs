using NSGE.Domain.Entity.Security;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSGE.Services.Services.Security
{
    public class FuncionalidadeService : IFuncionalidadeService
    {
        private readonly IFuncionalidadeRepository _funcionalidadeRepository;
        public FuncionalidadeService(IFuncionalidadeRepository funcionalidadeRepository)
        {
            _funcionalidadeRepository = funcionalidadeRepository;
        }
        public IList<Funcionalidade> List()
        {
            return _funcionalidadeRepository.List();
        }

        public IList<Funcionalidade> ListarIgnorandoFuncionalidadesDoPerfil(Perfil perfil)
        {
            //var funcionalidade = new List<Funcionalidade>();
            //var ids = perfil.Funcionalidades.Select(x => x.FuncionalidadeId).ToList();            

            return _funcionalidadeRepository.ListarIgnorandoFuncionalidadesDoPerfil(perfil);
        }
    }
}
