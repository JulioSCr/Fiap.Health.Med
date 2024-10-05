using Fiap.Health.Med.Application.Features.Medicos.Commands.AdicionarMedico;
using Fiap.Health.Med.Application.Features.Medicos.Commands.AtualizarMedico;
using Fiap.Health.Med.Application.ViewModel;
using Fiap.Health.Med.Domain.Entity;
using AutoMapper;

namespace Fiap.Health.Med.Application.MappingProfiles
{
    public class MedicoProfile : Profile
    {
        public MedicoProfile()
        {
            //Escrita
            CreateMap<AdicionarMedicoCommand, Medico>();
            CreateMap<AtualizarMedicoCommand, Medico>();


            //Leitura
            CreateMap<Medico, MedicoViewModel>();
            CreateMap<Medico, MedicoViewModel>()
                .ForMember(dest => dest.Especialidades, opt => opt.MapFrom(src => src.EspecialidadesMedicos))
                .ForMember(dest => dest.agendasMedico, opt => opt.MapFrom(src => src.EspecialidadesMedicos.SelectMany(e => e.Agendamentos ?? Enumerable.Empty<Agendamento>())));

        }
    }
}
