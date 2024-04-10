using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NSGE.CrosCutting.Enum
{
    public enum TipoNotificacaoEnum
    {
        [EnumText("Evento")]
        [EnumValue("E")]
        Evento,

        [EnumText("Checklist")]
        [EnumValue("C")]
        Checklist,

        [EnumText("Ordem Serviço Saída")]
        [EnumValue("OS_SAIDA")]
        OrdemServicoSaida,

        [EnumText("Ordem Serviço Entrada")]
        [EnumValue("OS_ENTRADA")]
        OrdemServicoEntrada,

        [EnumText("Financeiro")]
        [EnumValue("Financeiro")]
        Financeiro,

        [EnumText("Evento: Sublocação")]
        [EnumValue("EvSublocacao")]
        EventoSublocacao,

        [EnumText("Manutenção: Entrada")]
        [EnumValue("ManutencaoEntrada")]
        ManutencaoEntrada,

        [EnumText("Manutenção: Atualização")]
        [EnumValue("ManutencaoAtualizacao")]
        ManutencaoAtualizacao,

        [EnumText("Manutenção: Saída")]
        [EnumValue("ManutencaoSaida")]
        ManutencaoSaida,

        [EnumText("Evento: Feedback")]
        [EnumValue("EventoFeedback")]
        EventoFeedback,

        [EnumText("Proposta: Confirmação")]
        [EnumValue("PropostaConfirmada")]
        PropostaConfirmada,

        [EnumText("Evento: Proposta")]
        [EnumValue("EventoProposta")]
        EventoProposta,
    }
}
