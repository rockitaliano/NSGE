namespace NSGE.Infrastructure.SQLBuilder.Empresa
{
    public class EmpresaSQLContainer
    {
        public string GetAll()
        {
            return @"SELECT
                        Id, 
                        RazaoSocial, 
                        NomeFantasia, 
                        Cnpj, 
                        DataInscricao, 
                        InscricaoEstadual, 
                        InscricaoMunicipal, 
                        CodigoCNAE, 
                        Logo, 
                        CEP, 
                        Logradouro, 
                        Numero, 
                        Complemento, 
                        Bairro, 
                        Cidade, 
                        UF, 
                        DDD, 
                        NumeroTel
                            FROM Empresa";
        }

        public string Delete()
        {
            return @"DELETE FROM Empresa WHERE Id = @Id";
        }

        public string LoadId()
        {
            return @"SELECT * FROM Empresa Where Id = @Id";
        }

        public string Update()
        {
            return @"Update Empresa 
                          SET RazaoSocial =     @RazaoSocial,
                              NomeFantasia =    @NomeFantasia,
                              Cnpj =            @Cnpj,
                              DataInscricao =     @DataInscricao ,
                              InscricaoEstadual = @InscricaoEstadual, 
                              InscricaoMunicipal= @InscricaoMunicipal,
                              CodigoCNAE =        @CodigoCNAE,
                              Logo  =             @Logo,
                              CEP   =             @CEP,
                              Logradouro  =       @Logradouro,
                              Numero =            @Numero,
                              Complemento =       @Complemento,
                              Bairro =            @Bairro,
                              Cidade =            @Cidade,
                              UF =                @UF,
                              DDD =               @DDD,
                              NumeroTel =         @NumeroTel                             
                              
                            WHERE Id = @Id;";
        }
    }
}