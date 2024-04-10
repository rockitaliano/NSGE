using NSGE.CrossCutting.BaseEntity;
using System.ComponentModel.DataAnnotations;

namespace NSGE.Domain.Entity.Fabricante
{
    public class Fabricante : EntityBase
    {       
        public string Nome { get; set; }
    }
}