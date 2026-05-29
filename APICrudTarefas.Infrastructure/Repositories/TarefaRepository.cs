using APICrudTarefas.Application.Interfaces;
using APICrudTarefas.Domain.Entities;
using APICrudTarefas.Infrastructure.Data;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Infrastructure.Repositories
{
    public class TarefaRepository : ITarefaRepository
    {
        private readonly DapperContext _context;

        public TarefaRepository(DapperContext context)
        {
            _context = context;
        }

        public async Task<Guid> CriarAsync(Tarefa tarefa)
        {
            var sql = @"
            INSERT INTO Tarefas
            (
                Id,
                Titulo,
                Descricao,
                DataVencimento,
                Status,
                Prioridade,
                DataCriacao
            )
            VALUES
            (
                @Id,
                @Titulo,
                @Descricao,
                @DataVencimento,
                @Status,
                @Prioridade,
                @DataCriacao
            )";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(sql, tarefa);

            return tarefa.Id;
        }

        public async Task AtualizarAsync(Tarefa tarefa)
        {
            var sql = @"
            UPDATE Tarefas
            SET
                Titulo = @Titulo,
                Descricao = @Descricao,
                DataVencimento = @DataVencimento,
                Status = @Status,
                Prioridade = @Prioridade
            WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(sql, tarefa);
        }

        public async Task RemoverAsync(Guid id)
        {
            var sql = @"
            DELETE FROM Tarefas
            WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            await connection.ExecuteAsync(sql, new { Id = id });
        }

        public async Task<Tarefa?> ObterPorIdAsync(Guid id)
        {
            var sql = @"
            SELECT *
            FROM Tarefas
            WHERE Id = @Id";

            using var connection = _context.CreateConnection();

            return await connection.QueryFirstOrDefaultAsync<Tarefa>(
                sql,
                new { Id = id });
        }

        public async Task<(IEnumerable<Tarefa> itens, int total)>ListarAsync(int pagina,int tamanhoPagina)
        {
            var offset = (pagina - 1) * tamanhoPagina;

            var sql = @"
            SELECT *
            FROM Tarefas
            ORDER BY DataCriacao DESC
            OFFSET @Offset ROWS
            FETCH NEXT @TamanhoPagina ROWS ONLY;

            SELECT COUNT(1)
            FROM Tarefas";

            using var connection = _context.CreateConnection();

            using var multi = await connection.QueryMultipleAsync(
                sql,
                new
                {
                    Offset = offset,
                    TamanhoPagina = tamanhoPagina
                });

            var tarefas = await multi.ReadAsync<Tarefa>();

            var total = await multi.ReadFirstAsync<int>();

            return (tarefas, total);
        }
    }
}
