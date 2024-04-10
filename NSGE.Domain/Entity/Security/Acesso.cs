namespace NSGE.Domain.Entity.Security
{
    public class Acesso
    {
        public bool Cadastrar { get; set; }
        public bool Editar { get; set; }
        public bool Excluir { get; set; }
        public bool Visualizar { get; set; }
        public bool Relatorio { get; set; }
    }
}