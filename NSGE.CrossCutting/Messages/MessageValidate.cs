namespace NSGE.CrosCutting.Messages
{
    using System;

         
    public class MessageValidate
    {
        private static global::System.Resources.ResourceManager? resourceMan;

        private static global::System.Globalization.CultureInfo? resourceCulture;
        
        internal MessageValidate()
        {
        }

        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager
        {
            get
            {
                if (object.ReferenceEquals(resourceMan, null))
                {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("NSGE.CrosCutting.Messages.MessageValidate", typeof(MessageValidate).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }

        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo? Culture
        {
            get
            {
                return resourceCulture;
            }
            set
            {
                resourceCulture = value;
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor campo {0} não pode ser inferior a data atual..
        /// </summary>
        public static string? BeforeDate
        {
            get
            {
                return ResourceManager?.GetString("BeforeDate", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Existem dados inválidos ou não preenchidos..
        /// </summary>
        public static string? DadosInvalidos
        {
            get
            {
                return ResourceManager?.GetString("DadosInvalidos", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Por favor informe um e-mail válido..
        /// </summary>
        public static string? EmailAddress
        {
            get
            {
                return ResourceManager.GetString("EmailAddress", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Selecione pelo menos uma opção..
        /// </summary>
        public static string? EnderecoTipoRequired
        {
            get
            {
                return ResourceManager.GetString("EnderecoTipoRequired", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Extensão de arquivo não suportado.
        /// </summary>
        public static string? ExceptionArquivoNaoSuportado
        {
            get
            {
                return ResourceManager.GetString("ExceptionArquivoNaoSuportado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O CNPJ informado não é valido..
        /// </summary>
        public static string? ExceptionCnpjInvalido
        {
            get
            {
                return ResourceManager.GetString("ExceptionCnpjInvalido", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O CNPJ informado já está cadastrado no sistema..
        /// </summary>
        public static string? ExceptionCnpjUnico
        {
            get
            {
                return ResourceManager.GetString("ExceptionCnpjUnico", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Cadastre pelo menos um contato..
        /// </summary>
        public static string? ExceptionContatoNaoCadastrado
        {
            get
            {
                return ResourceManager.GetString("ExceptionContatoNaoCadastrado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O CPF informado não é válido..
        /// </summary>
        public static string? ExceptionCpfInvalido
        {
            get
            {
                return ResourceManager.GetString("ExceptionCpfInvalido", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O CPF informado já está cadastrado no sistema..
        /// </summary>
        public static string? ExceptionCpfUnico
        {
            get
            {
                return ResourceManager.GetString("ExceptionCpfUnico", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um departamento cadastrado com essa descrição..
        /// </summary>
        public static string? ExceptionDepartamentoDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionDepartamentoDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O documento informado já está cadastrado no sistema..
        /// </summary>
        public static string? ExceptionDocumentoUnico
        {
            get
            {
                return ResourceManager.GetString("ExceptionDocumentoUnico", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe uma empresa cadastrada com a mesma razão social..
        /// </summary>
        public static string? ExceptionEmpresaDuplicada
        {
            get
            {
                return ResourceManager.GetString("ExceptionEmpresaDuplicada", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Cadastre pelo menos um endereço..
        /// </summary>
        public static string? ExceptionEndrecoNaoCadastrado
        {
            get
            {
                return ResourceManager.GetString("ExceptionEndrecoNaoCadastrado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Códigos inseridos com sucesso: {0}..
        /// </summary>
        public static string? ExceptionEstoqueCodigosInseridos
        {
            get
            {
                return ResourceManager.GetString("ExceptionEstoqueCodigosInseridos", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Os seguintes códigos não foram inseridos pois já estão em uso: {0}..
        /// </summary>
        public static string? ExceptionEstoqueCodigosNaoInseridos
        {
            get
            {
                return ResourceManager.GetString("ExceptionEstoqueCodigosNaoInseridos", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Existe um item utilizando este código interno {0}..
        /// </summary>
        public static string? ExceptionEstoqueExistente
        {
            get
            {
                return ResourceManager.GetString("ExceptionEstoqueExistente", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um evento cadastrado com o mesmo número da OS informada..
        /// </summary>
        public static string? ExceptionEventoDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionEventoDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um fabricante cadastrado com as mesmas características..
        /// </summary>
        public static string? ExceptionFabricanteDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionFabricanteDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Tamanho máximo suportado é {0}mb..
        /// </summary>
        public static string? ExceptionFileMaxSize
        {
            get
            {
                return ResourceManager.GetString("ExceptionFileMaxSize", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Atribua pelo menos uma função a esta pessoa..
        /// </summary>
        public static string? ExceptionFuncaoRequired
        {
            get
            {
                return ResourceManager.GetString("ExceptionFuncaoRequired", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um grupo de produto cadastrado com as mesmas carcterísticas..
        /// </summary>
        public static string? ExceptionGrupoProdutoDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionGrupoProdutoDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Um ou mais itens não puderam ser excluídos pois estão em uso..
        /// </summary>
        public static string? ExceptionItemEmUso
        {
            get
            {
                return ResourceManager.GetString("ExceptionItemEmUso", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um local cadastrado com essa descrição para esse tipo de local..
        /// </summary>
        public static string? ExceptionLocalDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionLocalDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Login ou senha inválidos..
        /// </summary>
        public static string? ExceptionLoginInvalido
        {
            get
            {
                return ResourceManager.GetString("ExceptionLoginInvalido", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe uma marca cadastrada com essa descrição..
        /// </summary>
        public static string? ExceptionMarcaDuplicada
        {
            get
            {
                return ResourceManager.GetString("ExceptionMarcaDuplicada", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um modelo de veículo cadastrado com essa descrição..
        /// </summary>
        public static string? ExceptionModeloDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionModeloDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um email cadastrado para este tipo de notificação..
        /// </summary>
        public static string? ExceptionNotificacaoDuplicada
        {
            get
            {
                return ResourceManager.GetString("ExceptionNotificacaoDuplicada", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe uma ordem de serviço cadastrada com os mesmos dados informados, por favor verifique os seguintes dados: número, descrição, saída para o evento e cliente..
        /// </summary>
        public static string? ExceptionOrdemServicoDuplicada
        {
            get
            {
                return ResourceManager.GetString("ExceptionOrdemServicoDuplicada", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um perfil cadastrado com esse nome..
        /// </summary>
        public static string? ExceptionPerfilDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionPerfilDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O perfil não pôde ser excluído pois está em uso..
        /// </summary>
        public static string? ExceptionPerfilNaoPodeSerExcluido
        {
            get
            {
                return ResourceManager.GetString("ExceptionPerfilNaoPodeSerExcluido", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Associe uma ou mais funcionalidades para este perfil..
        /// </summary>
        public static string? ExceptionPerfilSemFuncionalidade
        {
            get
            {
                return ResourceManager.GetString("ExceptionPerfilSemFuncionalidade", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um dado genérico com esse texto para esta tela e campo..
        /// </summary>
        public static string? ExceptionSourceDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionSourceDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um status com essa descrição para esse tipo de cadastro..
        /// </summary>
        public static string? ExceptionStatusDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionStatusDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Desculpe este status não pode ser editado, usado internamente pelo sistema.
        /// </summary>
        public static string? ExceptionStatusLeitura
        {
            get
            {
                return ResourceManager.GetString("ExceptionStatusLeitura", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este telefone já está vinculado a este contato..
        /// </summary>
        public static string? ExceptionTelefoneDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionTelefoneDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Adicione pelo menos um telefone ao contato..
        /// </summary>
        public static string? ExceptionTelefoneRequired
        {
            get
            {
                return ResourceManager.GetString("ExceptionTelefoneRequired", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um usuário com este email ou login..
        /// </summary>
        public static string? ExceptionUsuarioDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionUsuarioDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Associe pelo menos um perfil a este usuário..
        /// </summary>
        public static string? ExceptionUsuarioSemPerfil
        {
            get
            {
                return ResourceManager.GetString("ExceptionUsuarioSemPerfil", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Já existe um veículo cadastrado com as mesmas características..
        /// </summary>
        public static string? ExceptionVeiculoDuplicado
        {
            get
            {
                return ResourceManager.GetString("ExceptionVeiculoDuplicado", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este campo deve ter {2} caracteres..
        /// </summary>
        public static string? FixedLength
        {
            get
            {
                return ResourceManager.GetString("FixedLength", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este campo deve ter no mínimo {2} e no máximo {1} caracteres..
        /// </summary>
        public static string? Length
        {
            get
            {
                return ResourceManager.GetString("Length", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este campo deve ter no máximo {1} caracteres..
        /// </summary>
        public static string? MaxLength
        {
            get
            {
                return ResourceManager.GetString("MaxLength", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este campo deve ter no mínimo {2} caracteres..
        /// </summary>
        public static string? MinLength
        {
            get
            {
                return ResourceManager.GetString("MinLength", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor deve ser de {1} a {2}.
        /// </summary>
        public static string? Range
        {
            get
            {
                return ResourceManager.GetString("Range", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor campo {0} não pode ser menor que o valor do campo {1}..
        /// </summary>
        public static string? RangeDate
        {
            get
            {
                return ResourceManager.GetString("RangeDate", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor informado é inválido, utilize o sequinte formato 123,456.
        /// </summary>
        public static string? Regex3CasasDecimais
        {
            get
            {
                return ResourceManager.GetString("Regex3CasasDecimais", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor informado é inválido, utilize o sequinte formato 123,45.
        /// </summary>
        public static string? RegexMonetario
        {
            get
            {
                return ResourceManager.GetString("RegexMonetario", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Campo numérico..
        /// </summary>
        public static string? RegexNumber
        {
            get
            {
                return ResourceManager.GetString("RegexNumber", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O formato do número da ordem de serviço é inválido..
        /// </summary>
        public static string? RegexOS
        {
            get
            {
                return ResourceManager.GetString("RegexOS", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O formato da placa é inválido..
        /// </summary>
        public static string? RegexPlaca
        {
            get
            {
                return ResourceManager.GetString("RegexPlaca", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Por favor informe uma url válida, utilize o formato www.info3e.com.br.
        /// </summary>
        public static string? RegexUrl
        {
            get
            {
                return ResourceManager.GetString("RegexUrl", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Campo obrigatório..
        /// </summary>
        public static string? Required
        {
            get
            {
                return ResourceManager?.GetString("Required", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Este campo deve ter {1} caracteres. .
        /// </summary>
        public static string? StringLength
        {
            get
            {
                return ResourceManager.GetString("StringLength", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to Por favor informe um telefone válido..
        /// </summary>
        public static string? TelefoneInvalido
        {
            get
            {
                return ResourceManager.GetString("TelefoneInvalido", resourceCulture);
            }
        }

        /// <summary>
        ///   Looks up a localized string similar to O valor informado é inválido..
        /// </summary>
        public static string? ValorInvalido
        {
            get
            {
                return ResourceManager.GetString("ValorInvalido", resourceCulture);
            }
        }
    }
}