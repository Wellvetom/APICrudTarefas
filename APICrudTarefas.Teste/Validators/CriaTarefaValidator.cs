using APICrudTarefas.Application.DTO.Request;
using APICrudTarefas.Application.DTO.Validations;
using APICrudTarefas.Domain.Enums;
using FluentValidation.TestHelper;

public class CriarTarefaValidatorTests
{
    private readonly CriarTarefaValidator _validator;

    public CriarTarefaValidatorTests()
    {
        _validator = new CriarTarefaValidator();
    }

    [Fact]
    public void Deve_Falhar_Quando_Titulo_Eh_Vazio()
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
    public void Deve_Falhar_Quando_Titulo_Maior_Que_100()
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
    public void Deve_Falhar_Quando_DataVencimento_For_Passada()
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
    public void Deve_Passar_Quando_Modelo_Eh_Valido()
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