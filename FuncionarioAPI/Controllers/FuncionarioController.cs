using AutoMapper;
using FuncionarioAPI.Data;
using FuncionarioAPI.Data.Dto.FuncionarioDto;
using FuncionarioAPI.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuncionarioAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FuncionarioController : ControllerBase
    {

        private FuncionarioContext _context;
        private IMapper _mapper;

        public FuncionarioController(FuncionarioContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaFuncionario([FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            Funcionario funcionario = _mapper.Map<Funcionario>(funcionarioDto);

            _context.Funcionarios.Add(funcionario);
            _context.SaveChanges();
            return CreatedAtAction(nameof(RecuperarFuncionariosPorId), new { Id = funcionario.Id }, funcionario);
        }

        [HttpGet]
        public IActionResult RecuperarFuncionarios()
        {
            return Ok(_context.Funcionarios);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarFuncionariosPorId(int id)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario != null)
            {
                ReadFuncionarioDto funcionarioDto = _mapper.Map<ReadFuncionarioDto>(funcionario);

                return Ok(funcionario);
            }
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFuncionario(int id, [FromBody] UpdateFuncionarioDto funcionarioDto)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            _mapper.Map(funcionarioDto, funcionario);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteFuncionario(int id)
        {
            Funcionario funcionario = _context.Funcionarios.FirstOrDefault(funcionario => funcionario.Id == id);
            if (funcionario == null)
            {
                return NotFound();
            }
            _context.Remove(funcionario);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
