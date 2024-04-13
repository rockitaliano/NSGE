using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using NSGE.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace NSGE.Domain.Entity.Associative
{
    public class EventoPessoa : EntityBase
    {
        public string EventoId { get; set; }
        public string PessoaId { get; set; }

        public string Tipo { get; set; }

        [JsonProperty("TipoEnum")]
        public TipoFuncaoPessoaEnum? tipoFuncaoEnum { get; set; }

        public TipoFuncaoPessoaEnum TipoEnum
        {
            get
            {
                return EnumExtensions.GetEnumValue(tipoFuncaoEnum);
            }
        }

        [ForeignKey("EventoId")]
        public virtual Evento Evento { get; set; }

        [ForeignKey("PessoaId")]
        public virtual Pessoa Pessoa { get; set; }

        public EventoPessoa()
        { }

        public EventoPessoa(string eventoId, string pessoaId)
        {
            PessoaId = pessoaId;
            EventoId = eventoId;
        }
    }
}