using APICrudTarefas.Application.DTO.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Application.DTO.Validations
{
    public class CriarTarefaValidator
        : AbstractValidator<CriarTarefaRequest>
    {
        public CriarTarefaValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.DataVencimento)
                .GreaterThan(DateTime.UtcNow);

            RuleFor(x => x.Status)
                .IsInEnum();

            RuleFor(x => x.Prioridade)
                .IsInEnum();
        }
    }
}
