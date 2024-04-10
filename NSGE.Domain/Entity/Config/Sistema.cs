using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;

namespace NSGE.Domain.Entity.Config
{
    public class Sistema : EntityBase
    {
        public Key Key { get; set; }
        public string? Value { get; set; }
    }
}