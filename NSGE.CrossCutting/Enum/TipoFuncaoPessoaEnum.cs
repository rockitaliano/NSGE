namespace NSGE.CrosCutting.Enum
{
    public enum TipoFuncaoPessoaEnum
    {
        [EnumText("Cliente")]
        [EnumValue("cli")]
        Cliente = 0,

        [EnumText("Fornecedor")]
        [EnumValue("for")]
        Fornecedor = 1,

        [EnumText("Funcionário")]
        [EnumValue("func")]
        Funcionario = 2,

        [EnumText("Freelancer")]
        [EnumValue("free")]
        Freelancer = 3,

        [EnumText("Coordenador")]
        [EnumValue("coo")]
        Coordenador = 4,

        [EnumText("Técnico")]
        [EnumValue("tec")]
        Tecnico = 5,

        [EnumText("Representante Comercial")]
        [EnumValue("rpc")]
        RepresentanteComercial = 6,

        [EnumText("Motorista")]
        [EnumValue("mot")]
        Motorista = 7,

        [EnumText("Transportadora")]
        [EnumValue("tra")]
        Transportadora = 8,

        [EnumText("Produtor")]
        [EnumValue("produtor")]
        Produtor = 9,

        [EnumText("Almoxarife")]
        [EnumValue("almoxarife")]
        Almoxarife = 10,

        [EnumText("Sublocação")]
        [EnumValue("sublocação")]
        Sublocacao = 11,

        [EnumText("Proposta")]
        [EnumValue("proposta")]
        Proposta = 12,

        [EnumText("TodosPessoa")]
        [EnumValue("tp")]
        TodosPessoa = 13
    }
}