using System.ComponentModel.DataAnnotations;

namespace FuncionarioAPI.Models
{
    public class Funcionario
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo nome é Obrigatório")]
        public string Nome { get; set; }
        [Range(100000000, 999999999, ErrorMessage = "O RG tem que ter 9 Numeros")]
        public string RG { get; set; }
        [StringLength(15, ErrorMessage = "O Departamento não pode ter mais de 15 caracteres")]
        public virtual Departamento Departamento { get; set; }

        public int DepartamentoId { get; set; }

    }
}
