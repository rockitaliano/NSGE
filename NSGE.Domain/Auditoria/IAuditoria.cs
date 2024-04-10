namespace NSGE.Domain.Auditoria
{
    public interface IAuditoria
    {
        DateTime DataDeCadastro { get; set; }
        DateTime? DataDeAlteracao { get; set; }
        string UsuarioCadastroId { get; set; }
        string UsuarioAlteracaoId { get; set; }
    }
}