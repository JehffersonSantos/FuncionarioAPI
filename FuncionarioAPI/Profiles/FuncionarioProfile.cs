using AutoMapper;
using FuncionarioAPI.Data.Dto.FuncionarioDto;
using FuncionarioAPI.Models;

namespace FuncionarioAPI.Profiles
{
    public class FuncionarioProfile : Profile
    {
        public FuncionarioProfile()
        {
            CreateMap<CreateFuncionarioDto, Funcionario>();
            CreateMap<Funcionario, ReadFuncionarioDto>();
            CreateMap<UpdateFuncionarioDto, Funcionario>();
        }
    }
}
