namespace NSGE.CrosCutting.Enum
{
    public enum StatusPagamento
    {
        [EnumText("Pago")]
        [EnumValue("0")]
        Pago = 0,

        [EnumText("Em Aberto")]
        [EnumValue("1")]
        EmAberto = 1,

        [EnumText("Vencido")]
        [EnumValue("2")]
        Vencido = 2,

        [EnumText("Em Aberto/Vencido")]
        [EnumValue("3")]
        EmAbertoEVencido = 3,
    }
}