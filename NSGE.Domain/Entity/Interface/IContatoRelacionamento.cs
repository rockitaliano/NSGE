using NSGE.Domain.Models;

namespace NSGE.Domain.Entity.Interface
{
    public interface IContatoRelacionamento
    {
        string Id { get; set; }
        string ContatoId { get; set; }
        Contato? Contato { get; set; }
    }
}