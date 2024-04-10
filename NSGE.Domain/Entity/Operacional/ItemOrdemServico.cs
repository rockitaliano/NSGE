using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Entity.Security;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Operacional
{
    public class ItemOrdemServico : EntityBase
    {
        public ItemOrdemServico()
        {
            DataCadastro = DateTime.Now;
        }

        public ItemOrdemServico(string idOrdemServico, string idEstoque)
            : this()
        {
            IdOrdemServico = idOrdemServico;
            IdEstoque = idEstoque;
        }

        public string IdOrdemServico { get; set; }
        public string IdEstoque { get; set; }
        public bool Finalizado { get; set; }
        public string IdUsuario { get; set; }
        public DateTime DataCadastro { get; set; }

        //[ForeignKey("IdOrdemServico")]
        //public OrdemServico OrdemServico { get; set; }

        [ForeignKey("IdEstoque")]
        public Estoque Estoque { get; set; }

        [ForeignKey("IdUsuario")]
        public Usuario Usuario { get; set; }
    }
}