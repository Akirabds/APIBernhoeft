using Bernhoeft.GRT.Teste.Application.Requests.Queries.v1;
using FluentValidation;

namespace Bernhoeft.GRT.Teste.Application.Requests.Queries.v1.Validators
{
    public class GetAvisoRequestValidator : AbstractValidator<GetAvisoRequest>
    {
        public GetAvisoRequestValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
        }
    }
}
