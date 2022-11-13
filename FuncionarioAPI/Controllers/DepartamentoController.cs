using AutoMapper;
using FuncionarioAPI.Data.Dto.FuncionarioDto;
using FuncionarioAPI.Data;
using FuncionarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using FuncionarioAPI.Data.Dto.Departamento;
using System.Linq;

namespace FuncionarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartamentoController : ControllerBase
    {

        private FuncionarioContext _context;
        private IMapper _mapper;

        public DepartamentoController(FuncionarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost ]
        public IActionResult AdicionaDepartamento([FromBody] UpdateDepartamentoDto departamentoDto)
        {
            Departamento departamento = _mapper.Map<Departamento>(departamentoDto);

            _context.Departamentos.Add(departamento);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarDepartamentosPorId), new { Id = departamento.Id }, departamento);
        }

        [HttpGet]
        public IActionResult RecuperarDepartamentos()
        {
            return Ok(_context.Departamentos);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarDepartamentosPorId(int id)
        {
            Departamento departamento = _context.Departamentos.FirstOrDefault(departamento => departamento.Id == id);
            if (departamento != null)
            {
                ReadDepartamentoDto departamentoDto = _mapper.Map<ReadDepartamentoDto>(departamento);

                return Ok(departamento);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaDepartamento(int id, [FromBody] UpdateDepartamentoDto departamentoDto)
        {
            Departamento departamento = _context.Departamentos.FirstOrDefault(departamento => departamento.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            _mapper.Map(departamentoDto, departamento);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartamento(int id)
        {
            Departamento departamento = _context.Departamentos.FirstOrDefault(departamento => departamento.Id == id);
            if (departamento == null)
            {
                return NotFound();
            }
            _context.Remove(departamento);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
