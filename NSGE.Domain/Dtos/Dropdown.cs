using NSGE.Domain.Models;

namespace NSGE.Domain.Dtos
{
    public class Dropdown
    {
        public string? Value { get; set; }
        public string? Text { get; set; }
        public Pessoa? Pessoa { get; set; }
    }
}