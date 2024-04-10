using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces;

namespace NSGE.Services.Services
{
    public class ArquivoService : IArquivoService
    {
        private readonly IArquivoRepository _repository;
        private readonly IWebHostEnvironment _hostingEnvironment;

        public ArquivoService(IArquivoRepository repository, IWebHostEnvironment hostingEnvironment)
        {
            _repository = repository;
            _hostingEnvironment = hostingEnvironment;
        }

        public void IOLimparPastaTemporaria(string eventoId = null)
        {
            try
            {
                var dirTemp = new DirectoryInfo(PathTemporarioEvento());

                var data = DateTime.Now.AddHours(-2);

                dirTemp.GetDirectories().Where(x => x.CreationTime <= data).ToList().ForEach(x => x.Delete(true));

                if (!string.IsNullOrEmpty(eventoId))
                {
                    dirTemp = new DirectoryInfo(PathTemporarioEvento(eventoId));
                    if (dirTemp.Exists)
                        dirTemp.Delete(true);
                }
            }
            catch
            {
                // ignora os erros
            }
        }

        public IList<Arquivo> ListarPorEvento(string eventoId)
        {
            return _repository.ListarPorEvento(eventoId);
        }

        private string PathTemporarioEvento(string eventoId = null)
        {
            var path = "~/content/uploads/evento/temporario";
            var serverPath = Path.Combine(_hostingEnvironment.ContentRootPath, path);

            if (!string.IsNullOrEmpty(eventoId))
                serverPath = Path.Combine(serverPath, eventoId);

            return serverPath;
        }

    }
}