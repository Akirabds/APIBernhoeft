using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validators
{
    public class UpdateAvisoMensagemRequestValidator : AbstractValidator<UpdateAvisoMensagemRequest>
    {
        public UpdateAvisoMensagemRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Mensagem).NotEmpty();
        }
    }
}
