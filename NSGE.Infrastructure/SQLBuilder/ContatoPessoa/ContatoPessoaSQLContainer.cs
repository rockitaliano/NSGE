namespace NSGE.Infrastructure.SQLBuilder.ContatoPessoa
{
    public class ContatoPessoaSQLContainer
    {
        public string RecuperarPessoa()
        {
            return @"SELECT
                        Id, 
                        ContatoId, 
                        PessoaId
                            FROM ContatoPessoa 
                                WHERE (PessoaId = @Id) OR ((PessoaId IS  NULL) AND (@Id IS  NULL))";
        }
    }
}