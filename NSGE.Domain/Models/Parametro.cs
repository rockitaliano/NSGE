using NSGE.CrossCutting.BaseEntity;

namespace NSGE.Domain.Models
{
    public class Parametro : EntityBase
    {
        public string? Key { get; set; }
        public string? Value { get; set; }
        public string? Descricao { get; set; }
    }
}