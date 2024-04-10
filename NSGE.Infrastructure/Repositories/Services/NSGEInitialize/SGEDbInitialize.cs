using Dapper;
using NSGE.CrosCutting.Enum;
using NSGE.CrossCutting.Encript;
using NSGE.Domain.Entity.Security;
using NSGE.Domain.Models;
using NSGE.Infrastructure.Context.Interface;

namespace NSGE.Infrastructure.Repositories.ImplementRepository.NSGEInitialize
{
    public class SGEDbInitialize
    {
        private readonly IDapperContext _context;

        public SGEDbInitialize(IDapperContext context)
        {
            _context = context;
            InitilizeUserAdmin();
            InitializeTableFuncionalidade();
            InitializeStatusPessoa();
        }

        public void InitializeTableFuncionalidade()
        {
            using var connection = _context.CreateConnection();

            // Verifica se as funcionalidades já existem no banco de dados
            var existingFuncionalidades = connection.Query<Funcionalidade>("SELECT * FROM Funcionalidade");

            // Se não existirem funcionalidades, insere as funcionalidades
            if (!existingFuncionalidades.Any())
            {
                var listFuncionalidades = (FuncionalidadeEnum[])Enum.GetValues(typeof(FuncionalidadeEnum));

                foreach (var func in listFuncionalidades)
                {
                    connection.Execute("INSERT INTO Funcionalidade (Nome, Descricao) VALUES (@Nome, @Descricao)",
                               new { Nome = func.EnumValue(), Descricao = func.EnumDescription() });
                }
            }
        }

        protected void InitilizeUserAdmin()
        {
            using var connection = _context.CreateConnection();

            // Verifica se o usuário administrador já existe no banco de dados
            var admin = connection.QueryFirstOrDefault<Usuario>("SELECT * FROM Usuario WHERE Login = @Login", new { Login = "admin" });
            // Se o usuário não existir, insere o usuário administrador
            if (admin == null)
            {
                string senhaCriptografada = "admin".Criptografar();
                var sql = @"INSERT INTO Usuario (Administrador, Status, Nome, Email, Login, Senha, DataDoCadastro)
                        VALUES (@Administrador, @Status, @Nome, @Email, @Login, @Senha, @DataDoCadastro)";

                connection.Execute(sql, new Usuario()
                {
                    Administrador = true,
                    Status = true,
                    Nome = "Administrador",
                    Email = "suporte@info3e.com.br",
                    Login = "admin",
                    Senha = senhaCriptografada,
                    DataDoCadastro = DateTime.Now
                });
            }
        }

        public void InitializeStatusPessoa()
        {
            using var connection = _context.CreateConnection();

            // Verifica se os status já existem no banco de dados
            var statusAtivo = connection.QueryFirstOrDefault<Status>("SELECT * FROM Status WHERE Descricao = @Descricao AND TipoDoCadastro = @Tipo",
                                                               new { Descricao = "Ativo", Tipo = TipoStatusEnum.Pessoa.EnumValue() });
            var statusInativo = connection.QueryFirstOrDefault<Status>("SELECT * FROM Status WHERE Descricao = @Descricao AND TipoDoCadastro = @Tipo",
                                                                 new { Descricao = "Inativo", Tipo = TipoStatusEnum.Pessoa.EnumValue() });

            // Se os status não existirem, insere os status
            if (statusAtivo == null)
            {
                connection.Execute("INSERT INTO Status (Descricao, TipoDoCadastro) VALUES (@Descricao, @Tipo)",
                           new { Descricao = "Ativo", Tipo = TipoStatusEnum.Pessoa.EnumValue() });
            }
            if (statusInativo == null)
            {
                connection.Execute("INSERT INTO Status (Descricao, TipoDoCadastro) VALUES (@Descricao, @Tipo)",
                           new { Descricao = "Inativo", Tipo = TipoStatusEnum.Pessoa.EnumValue() });
            }
        }
    }
}