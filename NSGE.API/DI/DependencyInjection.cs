﻿using Microsoft.Extensions.DependencyInjection;
using NSGE.Infrastructure.Context;
using NSGE.Infrastructure.Context.Interface;
using NSGE.Infrastructure.Repositories.ImplementRepository;
using NSGE.Infrastructure.Repositories.ImplementRepository.Almoxarifado;
using NSGE.Infrastructure.Repositories.ImplementRepository.Financeiro;
using NSGE.Infrastructure.Repositories.ImplementRepository.OrdemServicos;
using NSGE.Infrastructure.Repositories.ImplementRepository.Usuarios;
using NSGE.Infrastructure.Repositories.Interfaces;
using NSGE.Infrastructure.Repositories.Interfaces.Almoxarifado;
using NSGE.Infrastructure.Repositories.Interfaces.Financeiro;
using NSGE.Infrastructure.Repositories.Interfaces.Salario;
using NSGE.Infrastructure.Repositories.Interfaces.Usuarios;
using NSGE.Infrastructure.SQLBuilder.Agenda;
using NSGE.Infrastructure.SQLBuilder.Almoxarifado;
using NSGE.Infrastructure.SQLBuilder.Arquivo;
using NSGE.Infrastructure.SQLBuilder.Banco;
using NSGE.Infrastructure.SQLBuilder.Base;
using NSGE.Infrastructure.SQLBuilder.CentroDeCusto;
using NSGE.Infrastructure.SQLBuilder.ContaCorrente;
using NSGE.Infrastructure.SQLBuilder.ContasAReceber;
using NSGE.Infrastructure.SQLBuilder.ContatoEvento;
using NSGE.Infrastructure.SQLBuilder.ContatoPessoa;
using NSGE.Infrastructure.SQLBuilder.Departamento;
using NSGE.Infrastructure.SQLBuilder.Empresa;
using NSGE.Infrastructure.SQLBuilder.Evento;
using NSGE.Infrastructure.SQLBuilder.EventoEquipe;
using NSGE.Infrastructure.SQLBuilder.EventoProposta;
using NSGE.Infrastructure.SQLBuilder.EventoSublocacao;
using NSGE.Infrastructure.SQLBuilder.EventoVeiculo;
using NSGE.Infrastructure.SQLBuilder.Faturamento;
using NSGE.Infrastructure.SQLBuilder.Listas;
using NSGE.Infrastructure.SQLBuilder.Local;
using NSGE.Infrastructure.SQLBuilder.Notificacao;
using NSGE.Infrastructure.SQLBuilder.Operacional;
using NSGE.Infrastructure.SQLBuilder.Operacional.HistoricoEstoque;
using NSGE.Infrastructure.SQLBuilder.Parametro;
using NSGE.Infrastructure.SQLBuilder.Perfil;
using NSGE.Infrastructure.SQLBuilder.Pessoa;
using NSGE.Infrastructure.SQLBuilder.PlanoDeContas;
using NSGE.Infrastructure.SQLBuilder.RamoAtuacao;
using NSGE.Infrastructure.SQLBuilder.Salario;
using NSGE.Infrastructure.SQLBuilder.Security;
using NSGE.Infrastructure.SQLBuilder.Source;
using NSGE.Infrastructure.SQLBuilder.Status;
using NSGE.Infrastructure.SQLBuilder.TecnicoDia;
using NSGE.Infrastructure.SQLBuilder.TipoServico;
using NSGE.Infrastructure.SQLBuilder.Usuarios;
using NSGE.Services.Config;
using NSGE.Services.Interfaces;
using NSGE.Services.Interfaces.Agenda;
using NSGE.Services.Interfaces.Almoxarifado;
using NSGE.Services.Interfaces.Financeiro;
using NSGE.Services.Interfaces.OrdemServico;
using NSGE.Services.Interfaces.Propostas;
using NSGE.Services.Interfaces.Salario;
using NSGE.Services.Interfaces.Security;
using NSGE.Services.Services;
using NSGE.Services.Services.Agenda;
using NSGE.Services.Services.Almoxarifado;
using NSGE.Services.Services.CentroCusto;
using NSGE.Services.Services.Financeiro;
using NSGE.Services.Services.OrdemServico;
using NSGE.Services.Services.Propostas;
using NSGE.Services.Services.Salario;
using NSGE.Services.Services.Security;
using NSGEInfrastructureSQLBuilderMarca;
using NSGEInfrastructureSQLBuilderVeiculo;

namespace NSGE.Services.DI
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddCors(opt =>
            {
                opt.AddPolicy("AllowAnyOrigin", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddSingleton<IDapperContext, DapperContext>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddTransient<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IPropostaService, PropostaService>();
            services.AddScoped<IPropostaRepository, PropostaRepository>();
            services.AddScoped<IEventoService, EventoService>();
            services.AddScoped<IEventoRepository, EventoRepository>();
            services.AddScoped<IDiariaService, DiariaService>();
            services.AddScoped<IDiariaRepository, DiariaRepository>();
            services.AddScoped<ICheckListService, CheckListService>();
            services.AddScoped<ICheckListRepository, CheckListRepository>();
            services.AddScoped<IOperacionalService, OperacionalService>();
            services.AddScoped<IOperacionalRepository, OperacionalRepository>();
            services.AddScoped<IProdutoCompostoService, ProdutoCompostoService>();
            services.AddScoped<IProdutoCompostoRepository, ProdutoCompostoRepository>();
            services.AddScoped<IFabricanteService, FabricanteService>();
            services.AddScoped<IFabricanteRepository, FabricanteRepository>();
            services.AddScoped<IManutencaoService, ManutencaoService>();
            services.AddScoped<IManutencaoRepository, ManutencaoRepository>();
            services.AddScoped<ILocalService, LocalService>();
            services.AddScoped<ILocalRepository, LocalRepository>();
            services.AddScoped<IHistoricoEstoqueRepository, HistoricoEstoqueRepository>();
            services.AddScoped<IHistoricoEstoqueService, HistoricoEstoqueService>();
            services.AddScoped<IAgendaRepository, AgendaRepository>();
            services.AddScoped<IAgendaService, AgendaService>();
            services.AddScoped<IDiariaRepository, DiariaRepository>();
            services.AddScoped<IDiariaService, DiariaService>();
            services.AddScoped<IContasAPagarRepository, ContasAPagarRepository>();
            services.AddScoped<IContasAPagarService, ContasAPagarService>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IContaCorrenteService, ContaCorrenteService>();
            services.AddScoped<IPlanoDeContasService, PlanoDeContasService>();
            services.AddScoped<IPlanoDeContasRepository, PlanoDeContasRepository>();
            services.AddScoped<IFaturamentoService, FaturamentoService>();
            services.AddScoped<IFaturamentoRepository, FaturamentoRepository>();
            services.AddScoped<IBancoRepository, BancoRepository>();
            services.AddScoped<IBancoService, BancoService>();
            services.AddScoped<ICentroDeCustoRepository, CentroDeCustoRepository>();
            services.AddScoped<ICentroDeCustoService, CentroDeCustoService>();
            services.AddScoped<IPlanoDeContasRepository, PlanoDeContasRepository>();
            services.AddScoped<IPlanoDeContasService, PlanoDeContasService>();
            services.AddScoped<ITipoServicoRepository, TipoServicoRepository>();
            services.AddScoped<ITipoServicoService, TipoServicoService>();
            services.AddScoped<ISalarioRepository, SalarioRepository>();
            services.AddScoped<ISalarioService, SalarioService>();
            services.AddScoped<IContasAReceberRepository, ContasAReceberRepository>();
            services.AddScoped<IContasAReceberService, ContasAReceberService>();
            services.AddScoped<IArquivoService, ArquivoService>();
            services.AddScoped<IArquivoRepository, ArquivoRepository>();
            services.AddScoped<IContatoEventoService, ContatoEventoService>();
            services.AddScoped<IContatoEventoRepository, ContatoEventoRepository>();
            services.AddScoped<IEventoEquipeService, EventoEquipeService>();
            services.AddScoped<IEventoEquipeRepository, EventoEquipeRepository>();
            services.AddScoped<IEventoPropostaService, EventoPropostaService>();
            services.AddScoped<IEventoPropostaRepository, EventoPropostaRepository>();
            services.AddScoped<IEventoSublocacaoService, EventoSublocacaoService>();
            services.AddScoped<IEventoSublocacaoRepository, EventoSublocacaoRepository>();
            services.AddScoped<IEventoVeiculoService, EventoVeiculoService>();
            services.AddScoped<IEventoVeiculoRepository, EventoVeiculoRepository>();
            services.AddScoped<ITecnicoDiaService, TecnicoDiaService>();
            services.AddScoped<ITecnicoDiaRepository, TecnicoDiaRepository>();
            services.AddScoped<IContatoPessoaService, ContatoPessoaService>();
            services.AddScoped<IContatoPessoaRepository, ContatoPessoaRepository>();
            services.AddScoped<IParametroService, ParametroService>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<IAlmoxarifadoRepository, AlmoxarifadoRepository>();
            services.AddScoped<IAlmoxarifadoService, AlmoxarifadoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<IPerfilService, PerfilService>();
            services.AddScoped<IRamoAtuacaoRepository, RamoAtuacaoRepository>();
            services.AddScoped<IRamoAtuacaoService, RamoAtuacaoService>();
            services.AddScoped<IParametroRepository, ParametroRepository>();
            services.AddScoped<IFuncionalidadeRepository, FuncionalidadeRepository>();
            services.AddScoped<IFuncionalidadeService, FuncionalidadeService>();
            services.AddScoped<IBaseRepository, BaseRepository>();
            services.AddScoped<IEmpresaRepository, EmpresaRepository>();
            services.AddScoped<IEmpresaService, EmpresaService>();
            services.AddScoped<IOrdemServicoRepository, OrdemServicoRepository>();
            services.AddScoped<IOrdemServicoService, OrdemServicoService>();
            services.AddScoped<IItemOrdemServicoVersaoRepository, ItemOrdemServicoVersaoRepository>();
            services.AddScoped<IItemOrdemServicoVersaoService, ItemOrdemServicoVersaoService>();
            services.AddScoped<IItemSublocacaoOrdemServicoVersaoRepository, ItemSublocacaoOrdemServicoVersaoRepository>();
            services.AddScoped<IItemSublocacaoOrdemServicoVersaoService, ItemSublocacaoOrdemServicoVersaoService>();
            services.AddScoped<IObservacaoOrdemServicoVersaoService, ObservacaoOrdemServicoVersaoService>();
            services.AddScoped<IObservacaoOrdemServicoRepository, ObservacaoOrdemServicoRepository>();
            services.AddScoped<IObservacaoOrdemServicoService, ObservacaoOrdemServicoService>();
            services.AddScoped<ISourceService, SourceService>();
            services.AddScoped<IServiceSourceRepository, ServiceSourceRepository>();
            services.AddScoped<IObservacaoOrdemServicoVersaoService, ObservacaoOrdemServicoVersaoService>();
            services.AddScoped<IObservacaoOrdemServicoVersaoRepository, ObservacaoOrdemServicoVersaoRepository>();
            services.AddScoped<IStatusRepository, StatusRepository>();
            services.AddScoped<IStatusService, StatusService>();
            services.AddScoped<IDepartamentoRepository, DepartamentoRepository>();
            services.AddScoped<IDepartamentoService, DepartamentoService>();
            services.AddScoped<IVeiculoRepository, VeiculoRepository>();
            services.AddScoped<IVeiculoService, VeiculoService>();
            services.AddScoped<IMarcaService, MarcaService>();
            services.AddScoped<IMarcaRepository, MarcaRepository>();
            services.AddScoped<INotificacaoService, NotificacaoService>();
            services.AddScoped<INotificacaoRepository, NotificacaoRepository>();
            //services.AddScoped<IBaseList, BaseList>();
            services.AddSingleton<BancoSQLContainer>();
            services.AddSingleton<HistoricoEstoqueSQLContainer>();
            services.AddSingleton<ContasAReceberSQLContainer>();
            services.AddSingleton<FaturamentoSQLContainer>();
            services.AddSingleton<CentroDeCustoSQLContainer>();
            services.AddSingleton<ContaCorrenteSQLContainer>();
            services.AddSingleton<PlanoDeContasSQLContainer>();
            services.AddSingleton<TipoServicoSQLContainer>();
            services.AddSingleton<SalarioSQLContainer>();
            services.AddSingleton<ContasAReceberSQLContainer>();
            //services.AddScoped<BaseList>();
            services.AddSingleton<ListasSQLContainer>();
            services.AddSingleton<ClientesSQLContainer>();
            services.AddSingleton<AgendaSQLContainer>();
            services.AddSingleton<ArquivoSQLContainer>();
            services.AddSingleton<ClientesSQLContainer>();
            services.AddSingleton<EventoEquipeSQLContainer>();
            services.AddSingleton<EventoPropostaSQLContainer>();
            services.AddSingleton<LocalSQLContainer>();
            services.AddSingleton<EventoVeiculoSQLContainer>();
            services.AddSingleton<EventoSublocacaoSQLContainer>();
            services.AddSingleton<ContatoEventoSQLContainer>();
            services.AddSingleton<ArquivoSQLContainer>();
            services.AddSingleton<ContatoPessoaSQLContainer>();
            services.AddSingleton<ParametroSQLBuilder>();
            services.AddSingleton<TecnicoDiaSQLContainer>();
            services.AddSingleton<AlmoxarifadoSQLContainer>();
            services.AddSingleton<UsuariosSQLContainer>();
            services.AddSingleton<PerfilSQLContainer>();
            services.AddScoped<SistemaService>();
            services.AddSingleton<RamoAtuacaoSQLContainer>();
            services.AddSingleton<FuncionalidadeSQLContainer>();
            services.AddSingleton<BaseSQLContainer>();
            services.AddSingleton<EmpresaSQLContainer>();
            services.AddSingleton<OrdemServicoSQLContainer>();
            services.AddSingleton<ItemOrdemServicoVersaoSQLContainer>();
            services.AddSingleton<ItemSublocacaoOrdemServicoVersaoSQLContainer>();
            services.AddSingleton<SourceServiceSQLContainer>();
            services.AddSingleton<ObservacaoOrdemServicoVersaoSQLContainer>();
            services.AddSingleton<StatusSQLContainer>();
            services.AddSingleton<DepartamentoSQLContainer>();
            services.AddSingleton<VeiculoSQLContainer>();
            services.AddSingleton<MarcaSQLContainer>();
            services.AddSingleton<NotificacaoSQLContainer>();

            services.AddSingleton<EventoSQLContainer>();

            return services;
        }
    }
}