using APICrudTarefas.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Domain.Entities
{
    public class Tarefa
    {
        public Guid Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string? Descricao { get; set; }

        public DateTime DataVencimento { get; set; }

        public StatusTarefa Status { get; set; }

        public PrioridadeTarefa Prioridade { get; set; }

        public DateTime DataCriacao { get; set; }
    }
}
