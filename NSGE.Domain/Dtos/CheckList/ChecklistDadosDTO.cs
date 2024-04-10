namespace NSGE.Domain.Dtos.CheckList
{
    public class ChecklistDadosDTO
    {
        
        public string OS { get; set; }
        public string EventoId { get; set; }
        public string Cliente { get; set; }
        public string Evento { get; set; }

        public string ResponsavelDoChecklist { get; set; }

        public string ResponsavelComercial { get; set; }
        public string CoordenadorTecnico { get; set; }

        public double Versao { get; set; }

        /// <summary>
        ///  Lista de operadores Nome
        /// </summary>
        public IList<string>? Operadores { get; set; }

        /// <summary>
        /// Lista de Contatos nome - ddd telefone
        /// </summary>
        public IList<string> Contatos { get; set; }

        public DateTime? DataMontagem { get; set; }
        public DateTime? DataEvento { get; set; }
        public DateTime? DataTerminoEvento { get; set; }

        public bool Aprovado { get; set; }
    }
}