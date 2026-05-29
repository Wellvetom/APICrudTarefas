using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.DTO.Validations;
using APICrudTarefas.Domain.Enums;
using FluentValidation.TestHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Teste
{
    public class AtualizarTarefaTeste
    {
        private readonly AtualizarTarefaValidator _validator;

        public AtualizarTarefaTeste()
        {
            _validator = new AtualizarTarefaValidator();
        }

        [Fact]
        public void DeveFalharQuandoTituloEhVazio()
        {
            var model = new AtualizarTarefaRequest
            {
                Titulo = "",
                DataVencimento = DateTime.UtcNow.AddDays(1),
                Status = StatusTarefa.EmAndamento,
                Prioridade = PrioridadeTarefa.Alta
            };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Titulo);
        }

        [Fact]
        public void DeveFalharQuandoDataVencimentoForPassada()
        {
            var model = new AtualizarTarefaRequest
            {
                Titulo = "OK",
                DataVencimento = DateTime.UtcNow.AddDays(-10),
                Status = StatusTarefa.EmAndamento,
                Prioridade = PrioridadeTarefa.Alta
            };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.DataVencimento);
        }

        [Fact]
        public void DevePassarQuandoValido()
        {
            var model = new AtualizarTarefaRequest
            {
                Titulo = "OK",
                DataVencimento = DateTime.UtcNow.AddDays(10),
                Status = StatusTarefa.Concluida,
                Prioridade = PrioridadeTarefa.Baixa
            };

            var result = _validator.TestValidate(model);

            result.ShouldNotHaveAnyValidationErrors();
        }
    }
}
