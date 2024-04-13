using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Financeiro;
using NSGE.Domain.Entity.Propostas;
using NSGE.Services.Interfaces;
using NSGE.Services.Interfaces.Propostas;

namespace NSGE.API.Controllers.Financeiro
{
    [ApiController]
    [Route("[controller]")]
    public class ContasAPagarController : ControllerBase
    {
        private readonly IContasAPagarService _service;
        private readonly IPropostaService _proposta;

        public ContasAPagarController(IContasAPagarService service,
                                      IPropostaService proposta)
        {
            _service = service;
            _proposta = proposta;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var contasAPagar = new ContasAPagarFiltro();
            var contas = _service.Filtrar(contasAPagar);

            var status = _proposta.ListarPorTipo(TipoStatusEnum.Proposta)
                .Select(x => new { Text = x.Descricao, Value = x.Id });

            var resultado = new { Contas = contas, Status = status };
            

            return Ok(resultado);
        }
    }
}
