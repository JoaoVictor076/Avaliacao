using System.ComponentModel.DataAnnotations;

namespace Avaliacao.Models
{
    public class RegistroDeCartasViewModel
    {

        [MinLength(3, ErrorMessage = "Minimo de 3 letras.")]
        [MaxLength(255, ErrorMessage = "maximo ....")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O endereço é obrigatorio...") ]
        public string  Endereco { get; set; }

        [Range(1,15)]
        public int Idade { get; set; }
        [MaxLength(500, ErrorMessage = "maximo ....")]
        public string Textinho { get; set; }
    }
}
