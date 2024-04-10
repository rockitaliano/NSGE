namespace NSGE.Infrastructure.SQLBuilder.Operacional.HistoricoEstoque
{
    public class HistoricoEstoqueSQLContainer
    {
        public string GetAllHistoricoEstoque()
        {
            return @"SELECT
                            HE.Id, 
                            HE.IdEstoque, 
                            HE.IdOrdemServico, 
                            HE.IdStatus, 
                            HE.Data AS Data, 
                            HE.Tipo, 
                            HE.IdUsuario,
                            PR.Nome AS ProdutoNome,
                            E.CodigoInterno AS CodigoInterno,
                            OS.NumeroDaOS AS NumeroDaOS,
                            EV.Nome AS EventoNome,
                            PE.Nome AS ClienteNome,
                            ST.Descricao AS StatusDescricao
                            FROM HistoricoEstoque HE
                            INNER JOIN Estoque E ON E.Id = HE.IdEstoque
                            INNER JOIN ordemservico OS on OS.Id = HE.IdOrdemServico
                            INNER JOIN status ST on ST.Id = HE.IdStatus
                            INNER JOIN usuario US ON US.Id = HE.IdUsuario
                            INNER JOIN produto PR ON PR.Id = E.IdProduto
                            INNER JOIN evento EV ON EV.Id = OS.IdDoEvento
                            INNER JOIN pessoa PE ON PE.Id = OS.IdDoCliente
                        WHERE Data >= date_sub(CURDATE(), INTERVAL 45 DAY);";
        }

        public string ListarPorTipo()
        {
            return @"SELECT 
                        Id, 
                        Descricao, 
                        TipoDoCadastro, 
                        Leitura 
                        FROM Status  
                    WHERE TipoDoCadastro = '{WHERE}' ORDER BY Descricao ASC";

        }
    }
}