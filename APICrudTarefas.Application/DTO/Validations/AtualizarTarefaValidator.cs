
using APICrudTarefas.Application.DTO.Request;
using FluentValidation;

namespace APICrudTarefas.Application.DTO.Validations
{
    public class AtualizarTarefaValidator: AbstractValidator<AtualizarTarefaRequest>
    {
        public AtualizarTarefaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.DataVencimento)
                .Must(data => data > DateTime.UtcNow)
                .WithMessage("A data de vencimento deve ser futura.");

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.Prioridade)
                .IsInEnum();
        }
    }
}
