using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validators
{
    public class CreateAvisoRequestValidator : AbstractValidator<CreateAvisoRequest>
    {
        public CreateAvisoRequestValidator()
        {
            RuleFor(x => x.Titulo).NotEmpty();
            RuleFor(x => x.Mensagem).NotEmpty();
        }
    }
}
