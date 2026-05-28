using APICrudTarefas.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Application.Interfaces
{
    public interface ITarefaRepository
    {
        Task<Guid> CriarAsync(Tarefa tarefa);

        Task AtualizarAsync(Tarefa tarefa);

        Task RemoverAsync(Guid id);

        Task<Tarefa?> ObterPorIdAsync(Guid id);

        Task<(IEnumerable<Tarefa> itens, int total)>
            ListarAsync(int pagina, int tamanhoPagina);
    }
}
