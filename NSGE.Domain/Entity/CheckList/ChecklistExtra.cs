using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.CheckList
{
    public class ChecklistExtra : EntityBase
    {
        public string? OS { get; set; }
        public string? Text { get; set; }

        public string? ResponsavelId { get; set; }

        [ForeignKey("ResponsavelId")]
        public Usuario? Responsavel { get; set; }
    }
}