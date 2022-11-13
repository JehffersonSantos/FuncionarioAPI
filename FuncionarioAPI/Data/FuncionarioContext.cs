using FuncionarioAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace FuncionarioAPI.Data
{
    public class FuncionarioContext: DbContext
    {
        public FuncionarioContext(DbContextOptions<FuncionarioContext> opt) : base(opt)
        {

        }

        public DbSet<Funcionario> Funcionarios { get; set; }

        public DbSet<Departamento> Departamentos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Funcionario>()
                .HasOne(funcionario => funcionario.Departamento)
                .WithMany(departamento => departamento.Funcionarios)
                .HasForeignKey(funcionario => funcionario.DepartamentoId);
        }

    }
}
