﻿namespace Fiap.Health.Med.Application.ViewModel
{
    public class AgendamentoPacienteViewModel
    {
        public string Id { get; private set; }
        public string NomeMedico { get; private set; }
        public string NomeEspecialidade { get; private set; }
        public DateTime DataHoraAtendimento { get; private set; }
        public string StatusAgendamento { get; private set; }
    }
}
