using APICrudTarefas.Application.DTO.Request;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APICrudTarefas.Application.DTO.Validations
{
    public class LoginValidator : AbstractValidator<LoginRequest>
    {
        public LoginValidator()
        {
            RuleFor(x => x.Usuario)
           .NotEmpty();

            RuleFor(x => x.Senha)
           .NotEmpty();
        }
    }
}
