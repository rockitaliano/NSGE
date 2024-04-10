using NSGE.CrossCutting.BaseEntity;
using NSGE.Domain.Auditoria;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class Arquivo : EntityBase, IAuditoria
    {
        #region Propriedades
        public string EventoId { get; set; }

        public string Nome { get; set; }

        public int Tamanho { get; set; }

        /// <summary>
        /// SGE.Enttity.Enum.ArquivoAreaEnum
        /// </summary>
        public string Area { get; set; }
        #endregion

        #region IAuditoria
        public DateTime DataDeCadastro { get; set; }

        public DateTime? DataDeAlteracao { get; set; }

        public string UsuarioCadastroId { get; set; }

        public string UsuarioAlteracaoId { get; set; }
        #endregion

        [NotMapped]
        public bool Temporario { get; set; }

        [NotMapped]
        public string TamanhoFormatado
        {
            get
            {
                var kb = 1024;
                var mb = kb * 1024;

                double mbs = (double)Tamanho / mb;
                double kbs = Tamanho / kb;

                if (mbs > 1)
                    return string.Format("{0:N2} MB", mbs);

                return string.Format("{0} KB", kbs);
            }
        }
    }
}