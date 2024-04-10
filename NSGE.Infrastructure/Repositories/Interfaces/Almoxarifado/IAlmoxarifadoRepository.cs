using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;

namespace NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado
{
    public interface IAlmoxarifadoRepository
    {
        IList<ServicoAlmoxarifeRegistro> GetAlmoxarifadoAsync(); //ServicoAlmoxarifeRegistro
        Task<PessoaFiltro> GetNome(string pessoaId);
        Task<IList<ServicoAlmoxarife>> ServicoAlmoxarife();
        Task<IList<TipoServico>> GetTipoServico();
        Task<IList<Evento>> GetEventos();
        Task<IList<ServicoAlmoxarifeRegistro>> GetRegistros();
        Task<IList<Pessoa>> GetPessoas();
        Task<IList<RegistroViewModel>> FindBy(string pessoaId, string eventoId, DateTime? dataInicio, DateTime? dataFim);
        Task<ServicoAlmoxarifeRegistro> Load(string id);
        IList<TipoServico> Dropdown();
        IList<Pessoa> DropDownPessoa();
        Task Update(IEnumerable<ServicoAlmoxarifeRegistro> list);
    }

}