using APICrudTarefas.Application.Interfaces;
using APICrudTarefas.Domain.Entities;
using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.DTO.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using APICrudTarefas.Domain.Exceptions;

namespace APICrudTarefas.Application.Service
{
    public class TarefaService
    {
        private readonly ITarefaRepository _repository;

        public TarefaService(
            ITarefaRepository repository)
        {
            _repository = repository;
        }

        public async Task<Guid> CriarAsync(CriarTarefaRequest request)
        {
            var tarefa = new Tarefa
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                DataVencimento = request.DataVencimento,
                Status = request.Status,
                Prioridade = request.Prioridade,
                DataCriacao = DateTime.UtcNow
            };

            await _repository.CriarAsync(tarefa);

            return tarefa.Id;
        }

        public async Task AtualizarAsync(Guid id,AtualizarTarefaRequest request)
        {
            var tarefa =
                await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                throw new NotFoundException("Tarefa não encontrada.");

            tarefa.Titulo = request.Titulo;
            tarefa.Descricao = request.Descricao;
            tarefa.DataVencimento = request.DataVencimento;
            tarefa.Status = request.Status;
            tarefa.Prioridade = request.Prioridade;

            await _repository.AtualizarAsync(tarefa);
        }

        public async Task RemoverAsync(Guid id)
        {
            var tarefa =
                await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                throw new NotFoundException("Tarefa não encontrada.");

            await _repository.RemoverAsync(id);
        }

        public async Task<BuscaTarefaResponse?> ObterPorIdAsync(Guid id)
        {
            var tarefa =
                await _repository.ObterPorIdAsync(id);

            if (tarefa is null)
                return null;

            return new BuscaTarefaResponse
            {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataVencimento = tarefa.DataVencimento,
                Status = tarefa.Status,
                Prioridade = tarefa.Prioridade,
                DataCriacao = tarefa.DataCriacao
            };
        }

        public async Task<ResponsePaginado<BuscaTarefaResponse>>ListarAsync(int pagina,int tamanhoPagina)
        {
            var (itens, total) =
                await _repository.ListarAsync(
                    pagina,
                    tamanhoPagina);

            var tarefas = itens.Select(t => new BuscaTarefaResponse
            {
                Id = t.Id,
                Titulo = t.Titulo,
                Descricao = t.Descricao,
                DataVencimento = t.DataVencimento,
                Status = t.Status,
                Prioridade = t.Prioridade,
                DataCriacao = t.DataCriacao
            });

            return new ResponsePaginado<BuscaTarefaResponse>
            {
                Pagina = pagina,
                TamanhoPagina = tamanhoPagina,
                TotalRegistros = total,
                TotalPaginas =
                    (int)Math.Ceiling(
                        total / (double)tamanhoPagina),

                Dados = tarefas
            };
        }
    }
}
