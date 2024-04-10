namespace NSGE.Infrastructure.SQLBuilder.Operacional
{
    public class ManutencaoSQLContainer
    {
        public string GetAll()
        {
            return @"SELECT p.Nome as Produto, e.CodigoInterno as Patrimonio, m.Status as Status, m.Prioridade as TipoPrioridadeText, m.Entrada as Entrada, m.Saida as Saida, 
                            m.Problema, m.Solucao, m.Pecas, u.Nome as CriadoPor FROM manutencao m
                            INNER JOIN Estoque e ON e.Id = m.EstoqueId 
                            inner join usuario u on u.Id = m.IdUsuario
                            inner JOIN Produto p ON p.Id = e.IdProduto limit 200";
        }
    }
}