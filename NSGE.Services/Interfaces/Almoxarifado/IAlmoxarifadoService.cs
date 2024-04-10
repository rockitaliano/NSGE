using NSGE.CrosCutting.Enum;
using NSGE.Domain.Dtos;
using NSGE.Domain.Entity.Almoxarifado;
using NSGE.Domain.Entity.Clientes;
using NSGE.Domain.Models;

namespace NSGE.Services.Interfaces.Almoxarifado
{
    public interface IAlmoxarifadoService
    {
        Task<IList<ServicoAlmoxarifeRegistro>> GetAlmoxarifadoAsync();
        Task<PessoaFiltro> GetNome(string pessoaId);       
        //Task<IList<ServicoAlmoxarife>> ServicoAlmoxarife();
        //Task<IList<TipoServico>> GetTipoServico();
        //Task<IList<Evento>> GetEventos();
        Task<IList<RegistroViewModel>> FindBy(string pessoaId, string eventoId, DateTime? dataInicio, DateTime? dataFim);
        IList<AlmoxarifadoIndexViewModel> Grid(string eventoId, string pessoaId, DateTime? dataInicio, DateTime? dataFim);
        Task<ServicoAlmoxarifeRegistro> Load(string id);
        IList<TipoServico> DropDown();
        IList<Pessoa> DropDownPessoa(params TipoFuncaoPessoaEnum[] funcoes);

        Task Update(IEnumerable<ServicoAlmoxarifeRegistro> list);
        Task Delete(List<string> ids);
    }
}