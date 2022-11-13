using AutoMapper;
using FuncionarioAPI.Data.Dto.Departamento;
using FuncionarioAPI.Models;

namespace FuncionarioAPI.Profiles
{
    public class DepartamentoProfile : Profile
    {
        public DepartamentoProfile()
        {
            CreateMap<CreateDepartamentoDto, Departamento>();
            CreateMap<Departamento, ReadDepartamentoDto>();
            CreateMap<UpdateDepartamentoDto, Departamento>();

            teste
        }
    }
}
