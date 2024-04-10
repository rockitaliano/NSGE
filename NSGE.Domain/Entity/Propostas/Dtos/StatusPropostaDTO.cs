using NSGE.Domain.Models;

namespace NSGE.Domain.Entity.Propostas.Dtos
{
    public class StatusPropostaDTO
    {
        public string Id { get; set; }
        public string Descricao { get; set; }
        public string TipoDoCadastro { get; set; }
        public bool Leitura { get; set; }
    }
}