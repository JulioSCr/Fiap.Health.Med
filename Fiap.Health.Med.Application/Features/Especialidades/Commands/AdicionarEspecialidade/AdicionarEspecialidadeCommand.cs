﻿using MediatR;

namespace Fiap.Health.Med.Application.Features.Especialidades.Commands.AdicionarEspecialidade
{
    public class AdicionarEspecialidadeCommand : IRequest<Guid>
    {
        public AdicionarEspecialidadeCommand(string? nome, string? descricao)
        {
            Nome = nome;
            Descricao = descricao;
        }

        public AdicionarEspecialidadeCommand() { }

        public string? Nome { get; set; }
        public string? Descricao { get; set; }
    }
}
