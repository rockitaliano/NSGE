using System.ComponentModel.DataAnnotations;

namespace NSGE.CrossCutting.BaseEntity
{
    public class EntityBase : ICloneable
    {
        [Key]
        [StringLength(32, ErrorMessage = "Este campo deve ser uma GUID com 32 caracteres")]
        public string? Id { get; set; }

        public object Clone()
        {
            return MemberwiseClone();
        }
    }
}