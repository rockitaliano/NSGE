namespace NSGE.CrosCutting.Enum
{
    public enum TipoStatusEnum
    {
        [EnumText("Pessoa")]
        [EnumValue("PE")]
        Pessoa,

        [EnumText("Evento")]
        [EnumValue("EV")]
        Evento,

        [EnumText("Produto")]
        [EnumValue("PD")]
        Produto,

        [EnumText("Estoque")]
        [EnumValue("ES")]
        Estoque,

        [EnumText("Contas a Pagar")]
        [EnumValue("CP")]
        ContasAPagar,

        [EnumText("Contas a Receber")]
        [EnumValue("CR")]
        ContasAReceber,

        [EnumText("Proposta")]
        [EnumValue("PR")]
        Proposta,

        [EnumText("Checklist")]
        [EnumValue("CL")]
        Checklist,
    }
}