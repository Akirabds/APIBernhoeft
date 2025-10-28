using Bernhoeft.GRT.Teste.Application.Requests.Commands.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Commands.v1.Validators
{
    public class DeleteAvisoRequestValidator : AbstractValidator<DeleteAvisoRequest>
    {
        public DeleteAvisoRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
