using Fiap.Health.Med.Application.Features.Especialidades.Commands.AdicionarEspecialidade;
using Fiap.Health.Med.Application.Features.Especialidades.Commands.AtualizarEspecialidade;
using Fiap.Health.Med.Application.ViewModel;
using Fiap.Health.Med.Domain.Entity;
using AutoMapper;

namespace Fiap.Health.Med.Application.MappingProfiles
{
    public class EspecialidadeProfile : Profile
    {
        public EspecialidadeProfile()
        {
            //Escrita
            CreateMap<AdicionarEspecialidadeCommand, Especialidade>();
            CreateMap<AtualizarEspecialidadeCommand, Especialidade>();

            //Leitura
            CreateMap<Especialidade, EspecialidadeViewModel>()
               .ForMember(dest => dest.Medicos, opt => opt.MapFrom(src => src.EspecialidadeMedicos));
          
        }
    }
}
