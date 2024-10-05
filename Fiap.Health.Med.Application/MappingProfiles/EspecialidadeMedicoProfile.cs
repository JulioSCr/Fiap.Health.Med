using Fiap.Health.Med.Application.Features.EspecialidadesMedicos.Commands.AdicionarEspecialidadeMedico;
using Fiap.Health.Med.Application.Features.EspecialidadesMedicos.Commands.AtualizarEspecialidadeMedico;
using Fiap.Health.Med.Application.ViewModel;
using Fiap.Health.Med.Domain.Entity;
using AutoMapper;
using Fiap.Health.Med.Application.Features.Medicos.Commands.AdicionarAgenda;

namespace Fiap.Health.Med.Application.MappingProfiles
{
    public class EspecialidadeMedicoProfile : Profile
    {
        public EspecialidadeMedicoProfile()
        {
            //Escrita
            CreateMap<AdicionarEspecialidadeMedicoCommand, EspecialidadeMedico>();
            CreateMap<AtualizarEspecialidadeMedicoCommand, EspecialidadeMedico>();


            //Leitura
            CreateMap<EspecialidadeMedico, EspecialidadeMedicosViewModel>();

            CreateMap<AdicionarAgendaMedicoCommand, AgendaMedico>()
                .ConstructUsing(src => new AgendaMedico(
                   src.MedicoId,
                  (DayOfWeek) src.DiaSemana,
                   TimeSpan.Parse(src.HoraInicio),
                   TimeSpan.Parse(src.HoraFim)
                ));
        }    
    }
}
 