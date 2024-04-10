using NSGE.CrosCutting.Enum;
using NSGE.CrosCutting.Helper;
using NSGE.CrossCutting.CustomException;
using NSGE.CrossCutting.Extensions;
using NSGE.Domain.Entity.Config;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Services.Interfaces.Security;

namespace NSGE.Services.Config
{
    public class SistemaService
    {
        private static DateTime _expiracao;
        private static IList<Sistema> _cache;
        private static object _sync = new object();
        private readonly IUsuarioService _usuarioService;
        private readonly IBaseRepository _baseRepository;

        public SistemaService(IUsuarioService usuarioService, IBaseRepository baseRepository)
        {
            _usuarioService = usuarioService;
            _baseRepository = baseRepository;
        }

        private void VerificarCache()
        {
            if (_cache == null || _cache.Count == 0 || _expiracao == null || _expiracao < DateTime.Now)
            {
                lock (_sync)
                {
                    if (_cache == null || _cache.Count == 0 || _expiracao == null || _expiracao < DateTime.Now)
                    {
                        _expiracao = DateTime.Now.AddMinutes(ConfigHelper.CacheExpiracao);
                        _cache = _baseRepository.Filter();
                    }
                }
            }
        }

        public string GetValue(Key key)
        {
            VerificarCache();

            return _cache.FirstOrDefault(x => x.Key == key)?.Value;
        }

        public void Ativar(string serial)
        {
            try
            {
                var descriptografado = serial.Descriptografar();

                if (!SerialEstaValido(descriptografado))
                    throw new Exception();
            }
            catch (Exception ex)
            {
                throw new NSGECustomException($"Ops Serial inválido! {ex.Message}"); ;
            }

            Update(Key.Serial, serial);
        }

        public bool ValidarSerial()
        {
            var cripto = GetValue(Key.Serial);

            var serial = cripto.Descriptografar();

            return SerialEstaValido(serial);
        }

        public bool ValidarQuantidadeDeUsuarios()
        {
            var isFull = GetValue(Key.Serial).Descriptografar().IndexOf("full") != -1;

            if (isFull)
                return true;

            var totalDeUsuarios = _usuarioService.Count();
            var qtd = Convert.ToInt32(GetValue(Key.QuantidadeDeUsuarios));

            return totalDeUsuarios < qtd;
        }

        private bool SerialEstaValido(string serial)
        {
            var id = GetValue(Key.Id);

            //formato = id#yyyy-mm-dd#full
            var partes = serial.Split('#');

            var idValido = partes[0].Equals(id);
            var dataValida = DateTime.Parse(partes[1]) > DateTime.Now;
            var isFull = partes[2].Equals("full");

            if (idValido && isFull)
                return true;

            return idValido && dataValida;
        }

        private void Update(Key key, string value)
        {
            //var obj = Filter().FirstOrDefault(x => x.Key == key);

            //obj.Value = value;

            //Update(obj);

            //força atualizar o cache
            _expiracao = DateTime.Now.AddMinutes(-1);
        }
    }
}