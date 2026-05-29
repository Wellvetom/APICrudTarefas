using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.DTO.Validations;
using APICrudTarefas.Domain.Enums;
using FluentValidation.TestHelper;

public class CriaTarefaTeste
{
    private readonly CriarTarefaValidator _validator;

    public CriaTarefaTeste()
    {
        _validator = new CriarTarefaValidator();
    }

    [Fact]
    public void DeveFalharQuandoTituloEhVazio()
    {
        var model = new CriarTarefaRequest
        {
            Titulo = "",
            DataVencimento = DateTime.UtcNow.AddDays(1),
            Status = StatusTarefa.Pendente,
            Prioridade = PrioridadeTarefa.Media
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Titulo);
    }

    [Fact]
    public void DeveFalharQuandoTituloMaiorQue100()
    {
        var model = new CriarTarefaRequest
        {
            Titulo = new string('A', 101),
            DataVencimento = DateTime.UtcNow.AddDays(1),
            Status = StatusTarefa.Pendente,
            Prioridade = PrioridadeTarefa.Media
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.Titulo);
    }

    [Fact]
    public void DeveFalharQuandoDataVencimentoForPassada()
    {
        var model = new CriarTarefaRequest
        {
            Titulo = "Tarefa válida",
            DataVencimento = DateTime.UtcNow.AddDays(-1),
            Status = StatusTarefa.Pendente,
            Prioridade = PrioridadeTarefa.Media
        };

        var result = _validator.TestValidate(model);

        result.ShouldHaveValidationErrorFor(x => x.DataVencimento);
    }

    [Fact]
    public void DevePassarQuandoModeloEhValido()
    {
        var model = new CriarTarefaRequest
        {
            Titulo = "Tarefa válida",
            DataVencimento = DateTime.UtcNow.AddDays(1),
            Status = StatusTarefa.Pendente,
            Prioridade = PrioridadeTarefa.Media
        };

        var result = _validator.TestValidate(model);

        result.ShouldNotHaveAnyValidationErrors();
    }
}