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
    public class LoginRequestTeste
    {
        private readonly LoginValidator _validator;

        public LoginRequestTeste()
        {
            _validator = new LoginValidator();
        }
        [Fact]
        public void DeveFalharQuandoUsuarioEhVazio()
        {
            var model = new LoginRequest
            {
                Usuario = "",
                Senha = "123"
            };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Usuario);
        }
        [Fact]
        public void DeveFalharQuandoSenhaEhVazio()
        {
            var model = new LoginRequest
            {
                Usuario = "admin",
                Senha = ""
            };

            var result = _validator.TestValidate(model);

            result.ShouldHaveValidationErrorFor(x => x.Senha);
        }
    }
}
