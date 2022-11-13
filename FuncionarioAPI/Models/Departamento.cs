using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FuncionarioAPI.Models
{
    public class Departamento
    {
        [Key]
        [Required]
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }
        [JsonIgnore]
        public virtual List<Funcionario> Funcionarios { get; set; }
    }
}
