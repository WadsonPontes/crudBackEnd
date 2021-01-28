using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace aprendendoAPI.Models
{
    public class Estudo
    {
        [Key]
        public int Id { get; set; }

        // [Required(ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength(60, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        // [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 60 caracteres")]
        public string Titulo {get; set; }

        // [Required(ErrorMessage = "Este campo é obrigatório")]
        // [MaxLength(1024, ErrorMessage = "Este campo deve conter no máximo 1024 caracteres")]
        public string Descricao {get; set; }
    }
}