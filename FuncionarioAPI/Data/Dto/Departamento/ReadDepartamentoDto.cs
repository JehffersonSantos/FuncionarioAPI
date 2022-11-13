using FuncionarioAPI.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FuncionarioAPI.Data.Dto.Departamento
{
    public class ReadDepartamentoDto
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sigla { get; set; }

        public List<Funcionario> Funcionarios { get; set; }
    }
}
