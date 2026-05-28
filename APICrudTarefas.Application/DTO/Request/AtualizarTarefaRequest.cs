using APICrudTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Application.DTO.Request
{
    public class AtualizarTarefaRequest
    {
        public string Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusTarefa Status { get; set; }

        public PrioridadeTarefa Prioridade { get; set; }
    }
}
