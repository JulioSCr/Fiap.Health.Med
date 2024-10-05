using Fiap.Health.Med.Application.Features.Pacientes.Commands.AdicionarPaciente;
using Fiap.Health.Med.Application.Features.Pacientes.Commands.AtualizarPaciente;
using Fiap.Health.Med.Application.ViewModel;
using Fiap.Health.Med.Domain.Entity;
using AutoMapper;

namespace Fiap.Health.Med.Application.MappingProfiles
{
    public class PacienteProfile : Profile
    {
        public PacienteProfile()
        {
            //Escrita
            CreateMap<AdicionarPacienteCommand, Paciente>();
            CreateMap<AtualizarPacienteCommand, Paciente>();

            //Leitura
            CreateMap<Paciente, PacienteViewModel>()
                 .ForMember(dest => dest.agendasPaciente, opt => opt.MapFrom(src => src.Agendamentos));
        }

    }
}
