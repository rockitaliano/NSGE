using Microsoft.AspNetCore.Mvc;
using NSGE.Domain.Dtos.Evento;
using NSGE.Domain.Models;
using NSGE.Services.Interfaces;

namespace NSGE.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventoController : ControllerBase
    {
        private readonly IEventoService _eventoService;
        private readonly IArquivoService _arquivoService;
        private readonly IParametroService _parametroService;
        private readonly IPessoaService _pessooaService;
        private readonly ILocalService _localService;

        public EventoController(IEventoService eventoService, IArquivoService arquivoService, IParametroService parametroService, IPessoaService pessoaService, ILocalService localService)
        {
            _eventoService = eventoService;
            _arquivoService = arquivoService;
            _parametroService = parametroService;
            _pessooaService = pessoaService;
            _localService = localService;
        }

        [HttpGet]
        public async Task<ActionResult<EventoGrid>> Index(int? page = 1, int pageSize = 15)
        {
            try
            {
                var evento = await _eventoService.ListarEventos(page, pageSize);
                if (evento == null)
                {
                    return NotFound();
                }

                return Ok(evento);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Ocorreu um erro: {ex.Message}");
            }
        }
    }
}