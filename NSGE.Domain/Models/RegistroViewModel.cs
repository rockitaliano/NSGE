using NSGE.CrosCutting.Enum;
using NSGE.Domain.Entity.Almoxarifado;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NSGE.Domain.Models
{
    public class RegistroViewModel
    {
        #region Edição

        public string? Id { get; set; }
        public string? AlmoxarifeId { get; set; }
        public string? NumeroOS { get; set; }
        public string? Evento { get; set; }
        public double Total { get; set; }

        #endregion Edição

        [Required(ErrorMessage = "Campo obrigatório")]
        public string? TipoServicoId { get; set; }

        public string? TipoServicoDescricao { get; set; }
        public string? TipoServicoTipo { get; set; }
        public string? TipoServicoValor { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        public string Data { get; set; }

        public string DataFim { get; set; }

        public string? HoraInicio { get; set; }

        public string? HoraFim { get; set; }

        public string? ValorServico { get; set; }
        public bool ValorServicoPago { get; set; }

        public string? ValorAlimentacao { get; set; }
        public bool ValorAlimentacaoPago { get; set; }

        #region DB fields

        public DateTime DbData { private get; set; }
        public DateTime? DbDataFim { private get; set; }
        public TimeSpan? DbHoraInicio { get; set; }
        public TimeSpan? DbHoraFim { get; set; }
        public double DbValorServico { private get; set; }
        public double DbValorAlimentacao { private get; set; }

        #endregion DB fields

        #region Formatado

        public string TotalFormatado
        {
            get
            {
                return Total.ToString("N2");
            }
        }

        //[NotMapped]
        //[Display(Name = "Data")]
        //public string DataFormatada
        //{
        //    get
        //    {
        //        return this.Data.HasValue ? this.Data.Value.ToString("dd/MM/yyyy") : "N/A";
        //    }
        //}

        //[NotMapped]
        //[Display(Name = "Data Fim")]
        //public string DataFimFormatada
        //{
        //    get
        //    {
        //        return this.DataFim.HasValue ? this.DataFim.Value.ToString("dd/MM/yyyy") : "N/A";
        //    }
        //}

        #endregion Formatado

        public RegistroViewModel FromModel(ServicoAlmoxarifeRegistro model)
        {
            Id = model.Id;
            AlmoxarifeId = model.ServicoAlmoxarifeId;
            TipoServicoId = model.TipoServicoId;
            //TipoServicoDescricao = model.TipoServico.Descricao;
            //TipoServicoTipo = model.TipoServico.TipoValor.ToString();
            //TipoServicoValor = model.TipoServico.Valor.ToString(model.TipoServico.TipoValor == TipoValor.Fixo ? "N2" : "");
            Data = model.Data.ToShortDateString();
            DataFim = model.DataFim?.ToShortDateString();
            HoraInicio = model.HoraInicio?.ToString("hh\\:mm");
            HoraFim = model.HoraFim?.ToString("hh\\:mm");
            ValorServico = model.ValorServico.ToString("N2");
            ValorAlimentacao = model.ValorAlimentacao.ToString("N2");
            ValorServicoPago = model.ServicoPago;
            ValorAlimentacaoPago = model.AlimentacaoPago;

            return this;
        }

        public ServicoAlmoxarifeRegistro ToModel(string servicoAlmoxarifeId)
        {
            var model = new ServicoAlmoxarifeRegistro();

            model.Id = Id ?? model.Id;
            model.ServicoAlmoxarifeId = servicoAlmoxarifeId ?? AlmoxarifeId;
            model.TipoServicoId = TipoServicoId;
            model.Data = DateTime.Parse(Data);
            model.DataFim = string.IsNullOrEmpty(DataFim.ToString()) ? new Nullable<DateTime>() : DateTime.Parse(DataFim.ToString());
            model.HoraInicio = string.IsNullOrEmpty(HoraInicio) ? new Nullable<TimeSpan>() : TimeSpan.Parse(HoraInicio);
            model.HoraFim = string.IsNullOrEmpty(HoraFim) ? new Nullable<TimeSpan>() : TimeSpan.Parse(HoraFim);
            model.ValorServico = string.IsNullOrEmpty(ValorServico) ? 0 : double.Parse(ValorServico);
            model.ServicoPago = ValorServicoPago;
            model.ValorAlimentacao = string.IsNullOrEmpty(ValorAlimentacao) ? 0 : double.Parse(ValorAlimentacao);
            model.AlimentacaoPago = ValorAlimentacaoPago;

            return model;
        }

        public RegistroViewModel ConvertDbFields()
        {
            this.Data = DbData.ToShortDateString();
            this.DataFim = DbDataFim.HasValue ? DbDataFim.Value.ToShortDateString() : "";
            this.ValorServico = DbValorServico.ToString("N2");
            this.ValorAlimentacao = DbValorAlimentacao.ToString("N2");
            this.HoraInicio = DbHoraInicio.HasValue ? DbHoraInicio.Value.ToString("hh\\:mm") : "";
            this.HoraFim = DbHoraFim.HasValue ? DbHoraFim.Value.ToString("hh\\:mm") : "";

            return this;
        }
    }
}