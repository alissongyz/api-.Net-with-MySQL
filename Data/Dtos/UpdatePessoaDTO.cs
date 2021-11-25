using System.ComponentModel.DataAnnotations;

namespace apiweb.Data.Dtos
{
    public class UpdatePessoaDTO
    {
        [Range(1,30)]
        [Required(ErrorMessage = "Por Favor, digite um nome")]
        public string Nome { get; set; }
        [Range(1,20)]
        [Required(ErrorMessage = "Por Favor, digite sua cidade")]
        public string Cidade { get; set; }
        [Range(1,2)]
        [Required(ErrorMessage = "Por Favor, digite sua idade")]
        public int Idade { get; set; }
    }
}