using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Almoxarifado
{
    public class ServicoAlmoxarife : EntityBase
    {
        public string? PessoaId { get; set; }
        public string? EventoId { get; set; }
        public string? Descricao { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa? Pessoa { get; set; }

        [ForeignKey("EventoId")]
        public virtual Evento? Evento { get; set; }

        public virtual ICollection<ServicoAlmoxarifeRegistro> Registros { get; set; } = new List<ServicoAlmoxarifeRegistro>();
    }
}