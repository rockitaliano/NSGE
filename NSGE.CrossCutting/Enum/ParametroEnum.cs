namespace NSGE.CrosCutting.Enum
{
    public enum ParametroEnum
    {
        [EnumText("Endereço da empresa")]
        [EnumValue("Empresa.Endereco")]
        EmpresaEndereco,

        [EnumText("Email")]
        [EnumValue("Empresa.SMTP_Credential_Email")]
        EmpresaSMTPEmail,

        [EnumText("Email Nome de exibição")]
        [EnumValue("Empresa.SMTP_Credential_DisplayName")]
        EmpresaSMTPDisplayName,

        [EnumText("Senha Email")]
        [EnumValue("Empresa.SMTP_Credential_Password")]
        EmpresaSMTPSenha,

        [EnumText("Senha Email Novo")]
        [EnumValue("Empresa.SMTP_Credential_Password_New")]
        EmpresaSMTPSenhaNovo,

        [EnumText("Servidor")]
        [EnumValue("Empresa.SMTP_Server")]
        EmpresaSMTPServidor,

        [EnumText("Porta do Servidor")]
        [EnumValue("Empresa.SMTP_Porta")]
        EmpresaSMTPPorta,

        [EnumText("Use SSL")]
        [EnumValue("Empresa.SMTP_SSL")]
        EmpresaSMTPSSL,

        [EnumText("Use Default Credential")]
        [EnumValue("Empresa.SMTP_DefaultCredentials")]
        EmpresaSMTPDefaultCredentials,

        [EnumText("Endereço externo da aplicação")]
        [EnumValue("Empresa.Dominio_Externo")]
        EmpresaDominioExterno,

        [EnumText("Endereço interno da aplicação")]
        [EnumValue("Empresa.Dominio_Interno")]
        EmpresaDominioInterno,

        [EnumText("Valor base da diária técnica")]
        [EnumValue("Tecnico.ValorDiaria")]
        Tecnico_ValorDiaria,

        [EnumText("Valor base da diária do Coordenador")]
        [EnumValue("Coordenador.ValorDiaria")]
        Coordenador_ValorDiaria,

        [EnumText("Valor da alimentação dentro do RJ")]
        [EnumValue("Alimentacao.RJ")]
        Alimentacao_RJ,

        [EnumText("Valor da alimentação fora do RJ")]
        [EnumValue("Alimentacao.Fora")]
        Alimentacao_Fora,
    }
}