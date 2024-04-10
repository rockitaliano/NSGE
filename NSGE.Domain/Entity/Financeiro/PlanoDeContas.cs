using NSGE.CrossCutting.BaseEntity;
using NSGE.CrosCutting.Enum;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Entity.Financeiro
{
    public class PlanoDeContas : EntityBase
    {
        public PlanoDeContas()
        {
            ExibirEmContasAPagar = true;
            ExibirEmContasAReceber = true;
        }

        public NaturezaConta NaturezaDaConta { get; set; }
        public string Tipo { get; set; }
        public string ContaSintetica { get; set; }
        public string CodigoContabil { get; set; }
        public string Reduzido { get; set; }
        public string NomeDaConta { get; set; }
        public bool ExibirEmContasAPagar { get; set; }
        public bool ExibirEmContasAReceber { get; set; }

        [ForeignKey("ContaSintetica")]
        public virtual PlanoDeContas Pai { get; set; }

        public virtual ICollection<PlanoDeContas> Filhos { get; set; }

        public virtual ICollection<ContasAPagar> ContasAPagar { get; set; }

        public virtual ICollection<ContasAReceber> ContasAReceber { get; set; }

        public void GerarCodigos()
        {
            GerarCodigoContabil();
            GerarCodigoReduzido();
        }

        private void GerarCodigoContabil()
        {
            var posicoes = new string[] { "0", "0", "0", "0", "0", "0", "0", "0" };
            var codigos = this.Id;

            var espacos = new List<int> { 2, 4 };

            for (int i = 0; i < 8; i++)
            {
                if (codigos.Length > 0 && !espacos.Contains(i))
                {
                    posicoes[i] = codigos.Substring(0, 1);
                    codigos = codigos.Remove(0, 1);
                }
            }

            this.CodigoContabil = string.Join("", posicoes);
        }

        private void GerarCodigoReduzido()
        {
            this.Reduzido = this.CodigoContabil.Replace("0", "");
        }
    }
}